using Application.Models;
using Application.Services.Abstractions;
using Application.Services.Firebase;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class ProposalAssetService : IProposalAssetService
{
    private static readonly string PARENT_FOLDER = "ProposalAsset"; 
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFirebaseService _firebaseService;
    private readonly IClaimService _claimService;

    public ProposalAssetService(
        IUnitOfWork unitOfWork, 
        IMapper mapper, 
        IFirebaseService firebaseService,
        IClaimService claimService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _firebaseService = firebaseService;
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

        await _unitOfWork.SaveChangesAsync();

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
