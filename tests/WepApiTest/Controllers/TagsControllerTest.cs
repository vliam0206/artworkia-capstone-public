﻿using Domain.Test;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using Xunit.Abstractions;
using Application.Models;
using Domain.Entitites;
using Microsoft.AspNetCore.Http;

namespace WepApiTest.Controllers;

public class TagsControllerTest : SetupTest
{
    private readonly TagsController _tagsController;
    private readonly ITestOutputHelper output;

    public TagsControllerTest(ITestOutputHelper output)
    {
        this.output = output;

        _tagsController = new TagsController(
                       _tagServiceMock.Object,
                                  _mapperConfig);
    }

    [Fact]
    public async Task TagsController_GetAllTags_ShouldReturnCorrectData()
    {
        // Arrange
        var mockTags = new List<TagVM>
        {
            new TagVM { TagName = "Tag1" },
            new TagVM { TagName = "Tag2" },
            new TagVM { TagName = "Tag3" }
        };
        _tagServiceMock.Setup(service => service.GetAllTagsAsync())
            .ReturnsAsync(mockTags);

        var controller = new TagsController(
            _tagServiceMock.Object, _mapperConfig);

        // Act
        var result = await _tagsController.GetAllTags();
        var okResult = result as OkObjectResult;

        // Assert
        Assert.NotNull(okResult);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        var tags = okResult.Value as List<TagVM>;
        Assert.NotNull(tags);
        Assert.Equal(mockTags.Count, tags.Count);
        Assert.Contains(mockTags[0], tags);
        Assert.Contains(mockTags[1], tags);
        Assert.Contains(mockTags[2], tags);
    }

}
