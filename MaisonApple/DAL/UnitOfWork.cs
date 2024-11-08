﻿// ---------------------------------------------------------------
// Copyright (c) Kais Ben Hadj Hassen + Mohamed Riadh Sohnoun. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using DAL.CustomRepositories;
using DAO;
using DAO.DAO;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDAODataBase _DAODataBase;
        private readonly IServiceProvider _serviceProvider;
        public IProductRepository RepoProduct { get; set; }
        public IRepository<Category> RepoCategory { get; set; }
        public IProductImageRepository RepoProductImage { get; set; }
        public IRepository<User> RepoUser { get; set; }
        public IRepository<IdentityRole> RepoRole { get; set; }
        public IRepository<Command> RepoCommand { get; set; }
        public IOrderRepository RepoOrder { get; set; }
        public IRepository<Notification> RepoNotification { get; set; }
        public IRepository<ProductColorRelation> RepoProductColorRelation { get; set; }
        public IRepository<ProductColor> RepoProductColor { get; set; }
        public IFavoriteRepository RepoFavoris { get; set; }
        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            var dbContext = _serviceProvider.GetRequiredService<MaisonAppleContext>();
            _DAODataBase = new DAODataBase(dbContext);

            RepoProduct = new ProductRepository(new DAOEntities<Product>(dbContext), new DAOEntities<ProductColorRelation>(dbContext));
            RepoCategory = new Repository<Category>(new DAOEntities<Category>(dbContext));
            RepoProductImage = new ProductImageRepository(new DAOEntities<ProductImage>(dbContext));
            RepoUser = new Repository<User>(new DAOEntities<User>(dbContext));
            RepoRole = new Repository<IdentityRole>(new DAOEntities<IdentityRole>(dbContext));
            RepoCommand = new Repository<Command>(new DAOEntities<Command>(dbContext));
            RepoOrder = new OrderRepository(new DAOEntities<Order>(dbContext));
            RepoNotification = new Repository<Notification>(new DAOEntities<Notification>(dbContext));
            RepoProductColorRelation = new Repository<ProductColorRelation>(new DAOEntities<ProductColorRelation>(dbContext));
            RepoProductColor = new Repository<ProductColor>(new DAOEntities<ProductColor>(dbContext));
            RepoFavoris = new FavoriteRepository(new DAOEntities<Favoris>(dbContext));
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
