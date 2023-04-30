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
    public class ManufacturerServiceTest
    {
        private readonly ManufacturerService service;
        private readonly Mock<IManufacturerRepository> manufacturerRepositoryMoq;

        public ManufacturerServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            manufacturerRepositoryMoq = new Mock<IManufacturerRepository>();

            repositoryWrapperMoq.Setup(aboba => aboba.Manufacturer)
                .Returns(manufacturerRepositoryMoq.Object);

            service = new ManufacturerService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectCustomers()
        {
            return new List<object[]>
            {
                new object[] { new Manufacturer() },
                new object[] { new Manufacturer() { ManufacturerId = 101 } },
                new object[] { new Manufacturer() { ManufacturerId = 101, ManufacturerName = "Text" } }
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullExep()
        {
            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            //assert
            Assert.IsType<ArgumentNullException>(ex);
            manufacturerRepositoryMoq.Verify(aboba => aboba.Create(It.IsAny<Manufacturer>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectCustomers))]
        public async Task CreateAsyncNewUser_ShouldNot(Manufacturer manufacturer)
        {
            //arrange 
            var newCustomer = manufacturer;

            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newCustomer));

            //assert
            manufacturerRepositoryMoq.Verify(aboba => aboba.Create(It.IsAny<Manufacturer>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewUser_Should()
        {
            //arrange 
            var newCustomer = new Manufacturer() { ManufacturerId = 102, ManufacturerName = "Text", ManufacturerCountry = "Text" };

            //act 
            await service.Create(newCustomer);

            //assert
            manufacturerRepositoryMoq.Verify(aboba => aboba.Create(It.IsAny<Manufacturer>()), Times.Once);
        }
    }
}
