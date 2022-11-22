﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment1.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> Create(T t);

        Task<T> Update(T t);
        Task Delete(T t);
        Task<List<T>> FindAll();
        Task<T> FindById(Guid id);


    }
}
