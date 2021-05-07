using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DataContext.Repo
{
    public class ClassificationRepository : IClassificationRepository
    {
        private readonly ApiDataContext dc;

        public ClassificationRepository(ApiDataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<Classification>> GetClassification()
        {
            return await dc.Classification.ToListAsync();
        }
        public void AddClassification(Classification classification)
        {
            dc.Classification.AddAsync(classification);
        }
        public void DeleteClassification(int classificationId)
        {
            var classification = dc.Classification.Find(classificationId);
            dc.Classification.Remove(classification);
        }
        public async Task UpdateClassification(Classification classification)
        {
            dc.Entry(classification).State = EntityState.Modified;
            await dc.SaveChangesAsync();
        }
        public async Task<Classification> FindClassification(int classificationId)
        {
            return await dc.Classification.FindAsync(classificationId);
        }
    }
}