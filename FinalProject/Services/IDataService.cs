﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
        Task<T> Insert(T entity);
        Task<bool> Delete(int Id);
        Task<T> Update(int Id, T entity);
        Task<bool> Save();

    }
}
