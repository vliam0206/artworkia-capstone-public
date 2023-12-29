using AutoFixture;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Domain.Test;
using FluentAssertions;
using Infrastructure.Repositories.Commons;
using Moq;

namespace Infrastructure.Test.Repositories.Commons;

public class UnitOfWorkTest : SetupTest
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkTest()
    {
        _unitOfWork = new UnitOfWork(
                _dbContext,
                _accountRepositoryMock.Object,
                _userTokenRepositoryMock.Object,
                _artworkRepositoryMock.Object,
                _assetRepositoryMock.Object,
                _bookmarkRepositoryMock.Object,
                _categoryRepositoryMock.Object,
                _imageRepositoryMock.Object,
                _categoryArtworkDetailRepositoryMock.Object,
                _categoryServiceDetailRepositoryMock.Object,
                _chatBoxRepositoryMock.Object,
                _collectionRepositoryMock.Object,
                _commentRepositoryMock.Object,
                _likeRepositoryMock.Object,
                _messageRepositoryMock.Object,
                _notificationRepositoryMock.Object,
                _proposalAsseRepositoryMock.Object,
                _proposalRepositoryMock.Object,
                _reportRepositoryMock.Object,
                _requestRepositoryMock.Object,
                _reviewRepositoryMock.Object,
                _serviceRepositoryMock.Object,
                _serviceDetailRepositoryMock.Object,
                _tagDetailRepositoryMock.Object,
                _tagRepositoryMock.Object,
                _transactionHistoryRepositoryMock.Object,
                _walletHistoryRepositoryMock.Object,
                _walletRepositoryMock.Object,
                _followRepositoryMock.Object,
                _blockRepositoryMock.Object
                );
    }

    [Fact]
    public async Task TestUnitOfWork()
    {
        // arrange
        var mockData = MockAccountList(5);
        _accountRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(mockData);

        // act
        var items = await _unitOfWork.AccountRepository.GetAllAsync();

        // assert
        items.Should().BeEquivalentTo(mockData);
    }
}
