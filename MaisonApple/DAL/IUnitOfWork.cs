// ---------------------------------------------------------------
// Copyright (c) Kais Ben Hadj Hassen + Mohamed Riadh Sohnoun. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Entities;

namespace DAL
{
    public interface IUnitOfWork
    {
        IRepository<Product> RepoProduct { get; set; }
        IRepository<Category> RepoCategory { get; set; }
        IRepository<ProductImage> RepoProductImage { get; set; }
        /// <summary>
        /// Gets or creates a repository for a specific entity type.
        /// </summary>
        /// <typeparam name="T">The type of the entity for which to create or retrieve the repository.</typeparam>
        /// <returns>An instance of the repository for the specified entity type.</returns>
        //IRepository<T> Repository<T>() where T : class;

        /// <summary>
        /// Begins a new transaction asynchronously.
        /// </summary>
        Task BeginTransactionAsync();

        /// <summary>
        /// Commits the current transaction asynchronously.
        /// </summary>
        Task CommitTransactionAsync();

        /// <summary>
        /// Rolls back the current transaction asynchronously.
        /// </summary>
        Task RollbackTransactionAsync();

        /// <summary>
        /// Saves changes made in the unit of work asynchronously.
        /// </summary>
        Task SaveAsync();
    }
}
