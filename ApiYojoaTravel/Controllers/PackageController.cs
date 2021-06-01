using System.Collections.Generic;
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
        public Task<IEnumerable<Package>> GetPackage()
        {
            return uow.PackageApplication.GetPackage();
        }
        [HttpGet("{id}")]
        public Task<ActionResult<Package>> GetById(int id)
        {
            var package = uow.PackageApplication.FindPackage(id);
            return package;
        }
        [HttpPost]
        public async Task<IActionResult> AddPackage(Package package)
        {
            var activit = await uow.PackageApplication.AddPackage(package);
            if (activit == null)
            {
                return BadRequest();
            }
            return Ok(activit);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackage(int id, Package package)
        {
            var Package = await uow.PackageApplication.UpdatePackage(id, package);
            if (Package == null)
            {
                return BadRequest();

            }
            return StatusCode(201);           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            var Package = await uow.PackageApplication.DeletePackage(id);
            if (Package == null)
            {
                return BadRequest();
            }
            return StatusCode(201);         
        }
    }
}