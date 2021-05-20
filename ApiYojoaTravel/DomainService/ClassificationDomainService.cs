using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DomainService
{
    public class ClassificationDomainService: IClassificationDomainService
    {
         private readonly ApiDataContext dc;
        public ClassificationDomainService(ApiDataContext dc)
        {
            this.dc = dc;

        }
        public bool PostClassification(Classification Classification)
        {
            bool requiredField;
            requiredField = (Classification.Name == null) ? true : false;
            requiredField = (Classification.Description == null) ? true : false;
            return requiredField;
        }
        public async Task<ActionResult<Classification>> FindClassification(int ClassificationId)
        {
            var Classification = await dc.Classification.FirstOrDefaultAsync(x => x.ClassificationId == ClassificationId);
            return Classification;
        }
        public Classification DomainDeleteClassification(int id)
        {
            var Classification = dc.Classification.Find(id);
            if (Classification == null)
            {
                return null;
            }
            return Classification;
        }
        
    }
}