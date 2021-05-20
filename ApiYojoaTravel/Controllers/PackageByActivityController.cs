using System.Collections.Generic;
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
        public Task<IEnumerable<PackageByActivity>> GetPackageByActivity()
        {
            return uow.PackageByActivityApplication.GetPackageByActivity();
        }
        [HttpGet("{id}")]
        public Task<ActionResult<PackageByActivity>> GetById(int id)
        {
            var packageByActivity = uow.PackageByActivityApplication.FindPackageByActivity(id);
            return packageByActivity;
        }
        [HttpPost]
        public async Task<IActionResult> AddPackageByActivity(PackageByActivity packageByActivity)
        {
            var activit = await uow.PackageByActivityApplication.AddPackageByActivity(packageByActivity);
            if (activit == null)
            {
                return BadRequest();
            }
            return Ok(activit);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackageByActivity(int id, PackageByActivity packageByActivity)
        {
            var PackageByActivity = await uow.PackageByActivityApplication.UpdatePackageByActivity(id, packageByActivity);
            if (PackageByActivity == null)
            {
                return BadRequest();

            }
            return StatusCode(201);           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackageByActivity(int id)
        {
            var PackageByActivity = await uow.PackageByActivityApplication.DeletePackageByActivity(id);
            if (PackageByActivity == null)
            {
                return BadRequest();
            }
            return StatusCode(201);         
        }
    }
}