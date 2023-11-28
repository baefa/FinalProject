using FinalProject.Context;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace FinalProject.Services
{
    public class GenericDataService<T> : IDataService<T> where T : ModelObject
    {
        private readonly FinalProjectDbContext _context;

        public GenericDataService(FinalProjectDbContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
           var createdResult = _context.Set<T>().Add(entity);
           await _context.SaveChangesAsync();
           
           return createdResult;
        }

        public async Task<bool> Delete(int Id)
        {
            T entity = await _context.Set<T>().FirstOrDefaultAsync((e) => e.Id == Id);

            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> entities = await _context.Set<T>().ToListAsync();
            return entities; 
        }

        public async Task<T> GetById(int Id)
        {
            T entity = await _context.Set<T>().FirstOrDefaultAsync((e) => e.Id == Id);
            return entity;
        }
        public async Task<T> Update(int Id, T updatedEntity)
        {
            using (var context = new FinalProjectDbContext())
            {
                var entity = await context.Set<T>().FindAsync(Id);

                if (entity == null) throw new InvalidOperationException($"Entity with id {Id} not found");
                foreach (var property in typeof(T).GetProperties())
                {
                    if (property.Name == "Id") continue;
                    var newValue = property.GetValue(updatedEntity);
                    if (newValue != null) property.SetValue(entity, newValue);
                }

                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
