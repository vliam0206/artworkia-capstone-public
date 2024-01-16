﻿using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using System.Text.RegularExpressions;

namespace Application.Services;
public class TagService : ITagService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TagService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<TagVM>> GetAllTagsAsync()
    {
        var tagList = await _unitOfWork.TagRepository.GetAllAsync();
        var tagVMList = _mapper.Map<List<TagVM>>(tagList);
        return tagVMList;
    }

    public async Task<List<TagVM>> SearchTagsByNameAsync(string keyword)
    {
        var tagList = await _unitOfWork.TagRepository
            .SearchTagsByNameAsync(keyword);
        var tagVMList = _mapper.Map<List<TagVM>>(tagList);
        return tagVMList;
    }

    public async Task<TagVM?> GetTagByIdAsync(Guid tagId)
    {
        var tag = await _unitOfWork.TagRepository.GetByIdAsync(tagId);
        if (tag == null)
            throw new NullReferenceException("Cannot found tag!");
        var tagVM = _mapper.Map<TagVM>(tag);
        return tagVM;
    }

    public async Task<TagVM> AddTagAsync(TagModel tagModel)
    {
        var tagExist = await _unitOfWork.TagRepository
            .GetSingleByConditionAsync(x => x.TagName == tagModel.TagName);
        if (tagExist != null)
            throw new Exception($"Tag name '{tagExist.TagName}' is existed!");
        Tag newTag = _mapper.Map<Tag>(tagModel);
        await _unitOfWork.TagRepository.AddAsync(newTag);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TagVM>(newTag);
    }

    public async Task DeleteTagAsync(Guid tagId)
    {
        var result = await _unitOfWork.TagRepository.GetByIdAsync(tagId);
        if (result == null)
            throw new Exception("Cannot found tag!");
        _unitOfWork.TagRepository.Delete(result);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task EditTagAsync(Guid tagId, TagModel tagModel)
    {
        var tagExist = await _unitOfWork.TagRepository
            .GetTagByNameAsync(tagModel.TagName);
        if (tagExist?.Id != tagId)
            throw new Exception($"Tag name '{tagExist?.TagName}' is existed!");

        var oldTag = await _unitOfWork.TagRepository.GetByIdAsync(tagId);
        if (oldTag == null)
            throw new NullReferenceException("Cannot found tag!");
        oldTag.TagName = tagModel.TagName;
        _unitOfWork.TagRepository.Update(oldTag);
        await _unitOfWork.SaveChangesAsync();
    }


    public bool IsTagValid(string tagName)
    {
        // Kiểm tra xem tag có độ dài từ 2 đến 30 ký tự không
        if (tagName.Length > 30 || tagName.Length < 2)
        {
            return false;
        }
        // Kiểm tra xem tag chỉ có chứa chữ cái tiếng việt, số, và khoảng cách không
        string tagRegex = "^[0-9\\saAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ]+$";
        if (!Regex.IsMatch(tagName, tagRegex))
        {
            return false;
        }
        return true;
    }
}
