using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BusinessLogic.Tests
{
    public class CustomerServiceTest
    {
        private readonly CustomerService service;
        private readonly Mock<ICustomerRepository> customerRepositoryMoq;

        public CustomerServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>(); 
            customerRepositoryMoq = new Mock<ICustomerRepository>();
            
            repositoryWrapperMoq.Setup(aboba => aboba.Customer)
                .Returns(customerRepositoryMoq.Object);

            service = new CustomerService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectCustomers()
        {
            return new List<object[]>
            {
                new object[] { new Customer() { Surname = "", Name = "", Login = "", Password = "" } },
                new object[] { new Customer() { Surname = "Text", Name = "", Login = "", Password = "" } },
                new object[] { new Customer() { Surname = "Text", Name = "Text", Login = "", Password = "" } }
            };
        }
        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullExep()
        {
            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            //assert
            Assert.IsType<ArgumentNullException>(ex);
            customerRepositoryMoq.Verify(aboba => aboba.Create(It.IsAny<Customer>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectCustomers))]
        public async Task CreateAsynNewUser_ShouldNot(Customer customer)
        {
            //arrange 
            var newCustomer = customer;

            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newCustomer));

            //assert
            customerRepositoryMoq.Verify(aboba => aboba.Create(It.IsAny<Customer>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsynNewUser_Should()
        {
            //arrange 
            var newCustomer = new Customer
            {
                Surname = "Text",
                Name = "Text",
                Login = "Text",
                Password = "Text"
            };

            //act 
            await service.Create(newCustomer);

            //assert
            customerRepositoryMoq.Verify(aboba => aboba.Create(It.IsAny<Customer>()), Times.Once);
        }
    }
}
