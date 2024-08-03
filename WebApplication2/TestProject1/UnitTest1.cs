using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using WebApplication2.Controllers;
using WebApplication2.Model;
using WebApplication2.Services;
using Xunit;

namespace TestProject1
{
    public class PetsControllerTests
    {
        [Fact]
        public async Task Get_ShouldReturnListOfBreeds()
        {
            
            var mockService = new Mock<IPetService>();
            var expectedBreeds = new List<Breed>
            {
                new Breed { Breed = "Abyssinian", Country = "Ethiopia", Origin = "Natural", Coat = "Short", Pattern = "Ticked" }
            };
            mockService.Setup(service => service.GetBreedsAsync()).ReturnsAsync(expectedBreeds);

            var controller = new PetsController(mockService.Object);

           
            var result = await controller.Get();

           
            result.Should().BeEquivalentTo(expectedBreeds);
        }
    }
}
