using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class GoodServiceTest
    {
        private readonly GoodService service;
        private readonly Mock<IGoodRepository> goodRepositoryMoq;

        public GoodServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            goodRepositoryMoq = new Mock<IGoodRepository>();

            repositoryWrapperMoq.Setup(aboba => aboba.Good)
                .Returns(goodRepositoryMoq.Object);

            service = new GoodService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectCustomers()
        {
            return new List<object[]>
            {
                new object[] { new Good() },
                new object[] { new Good() { GoodId = 101 } },
                new object[] { new Good() { GoodId = 101, Title = "Text" } }
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullExep()
        {
            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            //assert
            Assert.IsType<ArgumentNullException>(ex);
            goodRepositoryMoq.Verify(aboba => aboba.Create(It.IsAny<Good>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectCustomers))]
        public async Task CreateAsyncNewUser_ShouldNot(Good good)
        {
            //arrange 
            var newCustomer = good;

            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newCustomer));

            //assert
            goodRepositoryMoq.Verify(aboba => aboba.Create(It.IsAny<Good>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewUser_Should()
        {
            //arrange 
            var newCustomer = new Good() { Price = 5.5m, GoodId = 101, Title = "Text", CategotyId = 1, ManufacturerId = 1, AmountOnStock = 10 };

            //act 
            await service.Create(newCustomer);

            //assert
            goodRepositoryMoq.Verify(aboba => aboba.Create(It.IsAny<Good>()), Times.Once);
        }
    }
}
