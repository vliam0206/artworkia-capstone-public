﻿using Application.Models;
using Domain.Entitites;

namespace Application.Services.Abstractions;
public interface ITagDetailService
{
    Task<TagListArtworkVM> GetTagListOfArtworkAsync(Guid artworkId);
    Task AddTagDetailAsync(TagDetailModel tagDetail);
    Task AddTagListArtworkAsync(TagListArtworkModel tagListArtworkModel, bool isSaveChanges = true);
    Task DeleteTagDetailAsync(Guid tagDetailId);
}
