﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Skinet.Core.Entities;
using Skinet.Core.Specifications;

namespace Skinet.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntityWithSpec(ISpecification<T> specification);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);

        Task<int> CountAsync(ISpecification<T> specification);
    }
}
