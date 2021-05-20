using System.Collections.Generic;
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
        public Task<IEnumerable<PackageByCategory>> GetPackageByCategory()
        {
            return uow.PackageByCategoryApplication.GetPackageByCategory();
        }
        [HttpGet("{id}")]
        public Task<ActionResult<PackageByCategory>> GetById(int id)
        {
            var packageByCategory = uow.PackageByCategoryApplication.FindPackageByCategory(id);
            return packageByCategory;
        }
        [HttpPost]
        public async Task<IActionResult> AddPackageByCategory(PackageByCategory packageByCategory)
        {
            var activit = await uow.PackageByCategoryApplication.AddPackageByCategory(packageByCategory);
            if (activit == null)
            {
                return BadRequest();
            }
            return Ok(activit);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackageByCategory(int id, PackageByCategory packageByCategory)
        {
            var PackageByCategory = await uow.PackageByCategoryApplication.UpdatePackageByCategory(id, packageByCategory);
            if (PackageByCategory == null)
            {
                return BadRequest();

            }
            return StatusCode(201);           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackageByCategory(int id)
        {
            var PackageByCategory = await uow.PackageByCategoryApplication.DeletePackageByCategory(id);
            if (PackageByCategory == null)
            {
                return BadRequest();
            }
            return StatusCode(201);         
        }
    }
}