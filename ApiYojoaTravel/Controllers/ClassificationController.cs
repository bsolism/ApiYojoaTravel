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
        public async Task<IActionResult> GetClassification()
        {
            var Classification = await uow.ClassificationRepository.GetClassification();
            return Ok(Classification);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Classification>> GetClassificationById(int classificationId)
        {
            return await uow.ClassificationRepository.FindClassification(classificationId);
        }
        [HttpPost]
        public async Task<IActionResult> AddClassification(Classification classification)
        {
            uow.ClassificationRepository.AddClassification(classification);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassification(int id, Classification classification)
        {
            if (id != classification.ClassificationId)
            {
                return BadRequest();
            }
            await uow.ClassificationRepository.UpdateClassification(classification);
            return StatusCode(201);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassification(int classificationId)
        {
            uow.ClassificationRepository.DeleteClassification(classificationId);
            await uow.SaveAsync();
            return Ok(classificationId);
        }
    }
}