using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestYojoaTravel
{
    [TestClass]
    public class ActividadTest
    {
        [TestMethod]
        
        public void PostActividad_Validated()
        {
            //Arrange
            ActivityDTO activity = new ActivityDTO
            {
                Name = "Caminata",
                Description = "Caminar senderos",
                InitTime = new DateTime(2021, 05, 06),
                EndTime = new DateTime(2021, 05, 06),
                Price = 200,
                ImageURL = "api/imageUrl"
            };

            //Act

            var activityDomainService = new ActivityDomainService();
            var resultado = activityDomainService.PostActivity(activity);

            //Assert
            Assert.AreEqual(false, resultado);
        }
    }
}
