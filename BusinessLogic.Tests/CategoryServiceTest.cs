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
    public class CategoryServiceTest
    {
        private readonly CategoryService service;
        private readonly Mock<ICategoryRepository> categotyRepositoryMoq;

        public CategoryServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            categotyRepositoryMoq = new Mock<ICategoryRepository>();

            repositoryWrapperMoq.Setup(aboba => aboba.Category)
                .Returns(categotyRepositoryMoq.Object);

            service = new CategoryService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectCustomers()
        {
            return new List<object[]>
            {
                new object[] { new Category() },
                new object[] { new Category() { CategotyId = 101 } }
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullExep()
        {
            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            //assert
            Assert.IsType<ArgumentNullException>(ex);
            categotyRepositoryMoq.Verify(aboba => aboba.Create(It.IsAny<Category>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectCustomers))]
        public async Task CreateAsyncNewUser_ShouldNot(Category category)
        {
            //arrange 
            var newCustomer = category;

            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newCustomer));

            //assert
            categotyRepositoryMoq.Verify(aboba => aboba.Create(It.IsAny<Category>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewUser_Should()
        {
            //arrange 
            var newCustomer = new Category() { CategotyId = 102, CategotyName = "Text" };

            //act 
            await service.Create(newCustomer);

            //assert
            categotyRepositoryMoq.Verify(aboba => aboba.Create(It.IsAny<Category>()), Times.Once);
        }
    }
}
