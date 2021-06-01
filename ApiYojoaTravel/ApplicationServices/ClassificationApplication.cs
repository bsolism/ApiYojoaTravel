using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.ApplicationServices
{
    public class ClassificationApplication: IClassificationApplication
    {
        private readonly ApiDataContext dc;
        private readonly IDomainUnitOfWork uow;
        public ClassificationApplication(ApiDataContext dc, IDomainUnitOfWork uow)
        {
            this.uow = uow;
            this.dc = dc;

        }
        public async Task<IEnumerable<Classification>> GetClassification()
        {
            return await dc.Classification.ToListAsync();
        }
        public Task<ActionResult<Classification>> FindClassification(int ClassificationId)
        {
            var Classification = uow.ClassificationDomainService.FindClassification(ClassificationId);
            if (Classification != null)
            {
                return Classification;
            }
            return null;

        }
        public async Task<IActionResult> AddClassification(Classification Classification)
        {
            var RequiredField = uow.ClassificationDomainService.PostClassification(Classification);
            if (!RequiredField)
            {
                dc.Classification.Add(Classification);
                await dc.SaveChangesAsync();
                return new ObjectResult(Classification);
            }
            return null;
        }
        public async Task<ActionResult> UpdateClassification(int id, Classification Classification)
        {
            if (id != Classification.ClassificationId)
            {
                return null;

            }
            dc.Entry(Classification).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(res);
        }
        public async Task<IActionResult> DeleteClassification(int ClassificationId)
        {
            var Classification = uow.ClassificationDomainService.DomainDeleteClassification(ClassificationId);
            if (Classification == null)
            {
                return null;
            }
            dc.Classification.Remove(Classification);
            await dc.SaveChangesAsync();
            return new ObjectResult(1);
        }
    }
}