﻿// ---------------------------------------------------------------
// Copyright (c) Kais Ben Hadj Hassen + Mohamed Riadh Sohnoun. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using DAO;
using DAO.DAO;
using Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDAODataBase _DAODataBase;
        private readonly IServiceProvider _serviceProvider;
        public IRepository<Product> RepoProduct { get; set; }
        public IRepository<Category> RepoCategory { get; set; }
        public IRepository<ProductImage> RepoProductImage { get; set; }

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            var dbContext = _serviceProvider.GetRequiredService<MaisonAppleContext>();
            _DAODataBase = new DAODataBase(dbContext);

            RepoProduct = new Repository<Product>(new DAOEntities<Product>(dbContext));
            RepoCategory = new Repository<Category>(new DAOEntities<Category>(dbContext));
            RepoProductImage = new Repository<ProductImage>(new DAOEntities<ProductImage>(dbContext));

        }

        /// <summary>
        /// Démarre de manière asynchrone une nouvelle transaction de base de données.
        /// </summary>
        public async Task BeginTransactionAsync()
        {
            await _DAODataBase.BeginTransactionAsync();
        }
        /// <summary>
        /// Valide de manière asynchrone la transaction en cours et applique les modifications à la base de données.
        /// </summary>
        public async Task CommitTransactionAsync()
        {
            await _DAODataBase.CommitTransactionAsync();
        }
        /// <summary>
        /// Annule de manière asynchrone la transaction en cours et restaure l'état précédent de la base de données.
        /// </summary>
        public async Task RollbackTransactionAsync()
        {
            await _DAODataBase.RollbackTransactionAsync();
        }
        /// <summary>
        /// Enregistre de manière asynchrone toutes les modifications apportées à la base de données.
        /// </summary>
        public async Task SaveAsync()
        {
            await _DAODataBase.SaveAsync();
        }
    }
}
