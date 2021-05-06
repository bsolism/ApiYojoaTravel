using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Controllers
{
    public class PackageController : BaseController
    {
        private readonly IUnitOfWork uow;
        public PackageController(IUnitOfWork uow)
        {
            this.uow = uow;

        }
        [HttpGet]
        public async Task<IActionResult> GetPackage()
        {
            var Package = await uow.PackageRepository.GetPackage();
            return Ok(Package);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackageById(int packageId)
        {
            return await uow.PackageRepository.FindPackage(packageId);
        }
        [HttpPost]
        public async Task<IActionResult> AddPackage(Package package)
        {
            uow.PackageRepository.AddPackage(package);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackage(int id, Package package)
        {
            if (id != package.PackageId)
            {
                return BadRequest();
            }
            await uow.PackageRepository.UpdatePackage(package);
            return StatusCode(201);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage(int packageId)
        {
            uow.PackageRepository.DeletePackage(packageId);
            await uow.SaveAsync();
            return Ok(packageId);
        }
    }
}