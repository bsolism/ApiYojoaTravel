using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Controllers
{
    public class PackageByCategoryController : BaseController
    {
        private readonly IUnitOfWork uow;
        public PackageByCategoryController(IUnitOfWork uow)
        {
            this.uow = uow;

        }
        [HttpGet]
        public async Task<IActionResult> GetPackageByCategory()
        {
            var PackageByCategory = await uow.PackageByCategoryRepository.GetPackageByCategory();
            return Ok(PackageByCategory);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageByCategory>> GetPackageByCategoryById(int packageByCategoryId)
        {
            return await uow.PackageByCategoryRepository.FindPackageByCategory(packageByCategoryId);
        }
        [HttpPost]
        public async Task<IActionResult> AddPackageByCategory(PackageByCategory packageByCategory)
        {
            uow.PackageByCategoryRepository.AddPackageByCategory(packageByCategory);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackageByCategory(int id, PackageByCategory packageByCategory)
        {
            if (id != packageByCategory.Id)
            {
                return BadRequest();
            }
            await uow.PackageByCategoryRepository.UpdatePackageByCategory(packageByCategory);
            return StatusCode(201);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackageByCategory(int packageByCategoryId)
        {
            uow.PackageByCategoryRepository.DeletePackageByCategory(packageByCategoryId);
            await uow.SaveAsync();
            return Ok(packageByCategoryId);
        }

    }
}