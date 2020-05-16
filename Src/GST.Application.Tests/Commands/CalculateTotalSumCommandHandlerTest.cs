
using GST.Application.Commands;
using GST.Application.Commands.Features.CalculateTotalSum;
using MediatR;
using Moq;
using NUnit.Framework;
using GST.Persistence;
using System.Collections.Generic;
using GST.Domain.Models;
using System.Threading.Tasks;
using Persistence.Abstractions.Interfaces;

namespace GST.Application.Tests.Commands
{
    [TestFixture]
    public class CalculateTotalSumCommandHandlerTest
    {
         
        [Test]
        public void CalculateTotalSum_With_TheCoresponding_Deal()
        {
            //Arrange
            var productsToMeasure = new string[3]
            {
                "tomato",
                "apple",
                "tomato"
            };

            string deal = "2 for 3";

            var productsInDeal = new string[3]
            {
                "tomato",
                "apple",
                "potato"
            };

            var repository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Mock };
            var mockRepo = repository.Create<IReadableRepository<Product>>();

            var productsUoWMock = new Mock<IProductDataUnitOfWork>();
            productsUoWMock.Setup(k => k.ReadProducts.GetByNameAsync(It.IsAny<string[]>()))
                .ReturnsAsync(() => new List<Product>() 
                {
                    new Product()
                    {
                        Name = "tomato",
                        Price = 3.00
                    },
                    new Product()
                    {
                        Name = "apple",
                        Price = 1.66
                    }
                });

            productsUoWMock
                .Setup(k => k.Products.UpdateAllAsync(It.IsAny<List<Product>>()))
                .Returns(() => Task.CompletedTask);

            var command = new CalculcateTotalSumCommand(productsToMeasure, deal, productsInDeal);
            var handler = new CalculateTotalSumCommandHandler(productsUoWMock.Object);

            //Act
            var finalSum = handler.Handle(command, new System.Threading.CancellationToken());

            //Assert
            Assert.AreEqual(finalSum, 6);
        }
    }
}
