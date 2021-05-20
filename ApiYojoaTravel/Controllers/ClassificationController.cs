using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Controllers
{
    public class ClassificationController : BaseController
    {
        private readonly IUnitOfWork uow;
        public ClassificationController(IUnitOfWork uow)
        {
            this.uow = uow;

        }
         [HttpGet]
        public Task<IEnumerable<Classification>> GetClassification()
        {
            return uow.ClassificationApplication.GetClassification();
        }
        [HttpGet("{id}")]
        public Task<ActionResult<Classification>> GetById(int id)
        {
            var classification = uow.ClassificationApplication.FindClassification(id);
            return classification;
        }
        [HttpPost]
        public async Task<IActionResult> AddClassification(Classification classification)
        {
            var activit = await uow.ClassificationApplication.AddClassification(classification);
            if (activit == null)
            {
                return BadRequest();
            }
            return Ok(activit);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassification(int id, Classification classification)
        {
            var Classification = await uow.ClassificationApplication.UpdateClassification(id, classification);
            if (Classification == null)
            {
                return BadRequest();

            }
            return StatusCode(201);           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassification(int id)
        {
            var Classification = await uow.ClassificationApplication.DeleteClassification(id);
            if (Classification == null)
            {
                return BadRequest();
            }
            return StatusCode(201);         
        }
    }
}