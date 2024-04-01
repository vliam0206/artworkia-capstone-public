using Application.Models;
using Application.Services.Abstractions;
using Application.Services.Firebase;
using AutoMapper;
using Domain.Entitites;
using Domain.Enums;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class ProposalAssetService : IProposalAssetService
{
    private static readonly Dictionary<ProposalAssetEnum, string> PROPOSALASSET_ENUM_VN = new Dictionary<ProposalAssetEnum, string>
    {
        { ProposalAssetEnum.Concept, "phác thảo" },
        { ProposalAssetEnum.Final, "cuối cùng" },
        { ProposalAssetEnum.Revision, "sửa đổi" }
    };
    private static readonly string PARENT_FOLDER = "ProposalAsset";
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFirebaseService _firebaseService;
    private readonly IClaimService _claimService;
    private readonly IMilestoneService _milstoneService;


    public ProposalAssetService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IFirebaseService firebaseService,
        IMilestoneService milstoneService,
        IClaimService claimService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _firebaseService = firebaseService;
        _milstoneService = milstoneService;
        _claimService = claimService;
    }

    public async Task<ProposalAssetVM> AddProposalAssetAsync(ProposalAssetModel proposalAssetModel)
    {
        // kiem tra xem proposal co ton tai khong
        var proposal = await _unitOfWork.ProposalRepository.GetByIdAsync(proposalAssetModel.ProposalId);
        if (proposal == null)
        {
            throw new NullReferenceException("Proposal not found");
        }

        // user phai gui tuan tu concept -> final -> revision
        var proposalAssets = await _unitOfWork.ProposalAssetRepository.GetProposalAssetsOfProposalAsync(proposalAssetModel.ProposalId);
        switch (proposalAssetModel.Type)
        {
            case ProposalAssetEnum.Final:
                if (!proposalAssets.Any(x => x.Type == ProposalAssetEnum.Concept))
                {
                    throw new Exception("Must send concept before sending final.");
                }
                break;
            case ProposalAssetEnum.Revision:
                if (!proposalAssets.Any(x => x.Type == ProposalAssetEnum.Final))
                {
                    throw new Exception("Must send final before sending revision.");
                }
                break;
        }

        // dat lai ten file
        string newProposalAssetName = $"{Path.GetFileNameWithoutExtension(proposalAssetModel.File.FileName)}_{DateTime.Now.Ticks}";
        string folderName = PARENT_FOLDER;
        string fileExtension = Path.GetExtension(proposalAssetModel.File.FileName);

        // upload file len firebase
        var url = await _firebaseService.UploadFileToFirebaseStorage(proposalAssetModel.File, newProposalAssetName, folderName);
        if (url == null)
        {
            throw new Exception("Upload file failed");
        }

        // map assetModel sang proposalAsset
        ProposalAsset proposalAsset = _mapper.Map<ProposalAsset>(proposalAssetModel);
        proposalAsset.Location = url;
        proposalAsset.ProposalAssetName = newProposalAssetName + fileExtension;
        await _unitOfWork.ProposalAssetRepository.AddAsync(proposalAsset);

        // map asset vao message
        var newMessage = new Message()
        {
            ChatBoxId = proposal.ChatBoxId,
            FileLocation = url,
            FileName = proposalAsset.ProposalAssetName
        };
        await _unitOfWork.MessageRepository.AddAsync(newMessage);

        if (proposalAssetModel.Type == ProposalAssetEnum.Final)
        {
            proposal.ProposalStatus = ProposalStateEnum.Completed;
            _unitOfWork.ProposalRepository.Update(proposal);
        }

        await _unitOfWork.SaveChangesAsync();

        // create proposal successfully -> add Init milestone
        await _milstoneService.AddMilestoneToProposalAsync(proposalAsset.ProposalId, $"Gửi tài nguyên thỏa thuận ({PROPOSALASSET_ENUM_VN[proposalAsset.Type]})");

        var proposalAssetVM = _mapper.Map<ProposalAssetVM>(proposalAsset);
        return proposalAssetVM;
    }

    public async Task<List<ProposalAssetVM>> GetProposalAssetsOfProposalAsync(Guid proposalId)
    {
        var listProposalAsset = await _unitOfWork.ProposalAssetRepository.GetProposalAssetsOfProposalAsync(proposalId);
        var listProposalAssetVM = _mapper.Map<List<ProposalAssetVM>>(listProposalAsset);
        return listProposalAssetVM;
    }
}
