using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Controllers
{
    public class PackageByActivityController : BaseController
    {
        private readonly IUnitOfWork uow;
        public PackageByActivityController(IUnitOfWork uow)
        {
            this.uow = uow;

        }
        [HttpGet]
        public async Task<IActionResult> GetPackageByActivity()
        {
            var PackageByActivity = await uow.PackageByActivityRepository.GetPackageByActivity();
            return Ok(PackageByActivity);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageByActivity>> GetPackageByActivityById(int packageByActivityId)
        {
            return await uow.PackageByActivityRepository.FindPackageByActivity(packageByActivityId);
        }
        [HttpPost]
        public async Task<IActionResult> AddPackageByActivity(PackageByActivity packageByActivity)
        {
            uow.PackageByActivityRepository.AddPackageByActivity(packageByActivity);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackageByActivity(int id, PackageByActivity packageByActivity)
        {
            if (id != packageByActivity.Id)
            {
                return BadRequest();
            }
            await uow.PackageByActivityRepository.UpdatePackageByActivity(packageByActivity);
            return StatusCode(201);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackageByActivity(int packageByActivityId)
        {
            uow.PackageByActivityRepository.DeletePackageByActivity(packageByActivityId);
            await uow.SaveAsync();
            return Ok(packageByActivityId);
        }

    }
}