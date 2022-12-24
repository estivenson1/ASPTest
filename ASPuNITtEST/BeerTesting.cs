using ASPTest.Controllers;
using ASPTest.Models;
using ASPTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPuNITtEST
{
    public class BeerTesting
    {
        private readonly BeerController _controller;
        private readonly IBeerService _service;

        public BeerTesting()
        {
            _service = new BeerService();
            _controller = new BeerController(_service);
        }

        [Fact]
        public void Get_OK()
        {
            var result=_controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_Quantity() 
        {
            var result = (OkObjectResult)_controller.Get();

            var beers = Assert.IsType<List<Beer>>(result.Value);
            Assert.True(beers.Count > 0);
        }

        [Fact]
        public void GetById_Ok()
        {
            int id = 1; 

            var result=_controller.GetByID(id);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_Exists()
        {
            //Arrange
            int id = 1;

            //Act
            var result = (OkObjectResult)_controller.GetByID(id);

            //Assert
            var beer =Assert.IsType<Beer>(result?.Value);
            Assert.True(beer != null);
            Assert.Equal(beer.Id,id );
        }

        [Fact]
        public void GetById_NotFound()
        {
            //Arrange
            int id = 11;

            //Act
            var result = _controller.GetByID(id);

            //Assert
            Assert.IsType<NotFoundResult>(result); 
        }

    }
}