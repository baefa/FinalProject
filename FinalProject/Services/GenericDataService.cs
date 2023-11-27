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
            try
            {
                using (var context = new FinalProjectDbContext())
                {
                    var existingEntity = await context.Set<T>().FindAsync(Id);

                    if (existingEntity != null)
                    {
                        foreach (var property in typeof(T).GetProperties())
                        {
                            if (property.Name != "Id")
                            {
                                var newValue = property.GetValue(updatedEntity);
                                property.SetValue(existingEntity, newValue);
                            }
                        }

                        await context.SaveChangesAsync();

                        return existingEntity;
                    }
                        throw new InvalidOperationException($"Entity with id {Id} not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the entity: {ex.Message}");
                throw;
            }
        }
    }
}
