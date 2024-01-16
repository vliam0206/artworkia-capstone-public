using Domain.Test;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using Xunit.Abstractions;
using Application.Models;

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

    //[Fact]
    //public async Task TagsController_GetAllTags_ShouldReturnCorrectData()
    //{
    //    // arrange
    //    var mockTags = MockTagList(5);
    //    _tagServiceMock.Setup(x => x.GetAllTagsAsync())
    //                   .ReturnsAsync(mockTags);

    //    // act
    //    var result = await _tagsController.GetAllTags();

    //    // assert
    //    var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
    //    var tags = okResult.Value.Should().BeAssignableTo<List<TagVM>>().Subject;
    //    tags.Count.Should().Be(10);
    //}

}
