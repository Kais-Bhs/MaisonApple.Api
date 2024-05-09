﻿// ---------------------------------------------------------------
// Copyright (c) Kais Ben Hadj Hassen + Mohamed Riadh Sohnoun. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using System.Linq.Expressions;
using DAO.DAO;

namespace DAL
{
    /// <summary>
    /// A concrete implementation of the generic repository interface for data access operations.
    /// </summary>
    /// <typeparam name="T">The entity type managed by the repository.</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDAOEntities<T> _DAOEntities;

        public Repository(IDAOEntities<T> daoEntities)
        {
            _DAOEntities = daoEntities;
        }
        /// <summary>
        /// Effectue une requête sur les entités en fonction du prédicat spécifié et renvoie une requête IQueryable.
        /// </summary>
        /// <param name="predicate">Le prédicat pour filtrer les entités.</param>
        /// <returns>Une requête IQueryable d'entités basée sur le prédicat.</returns>
        public virtual async Task<IQueryable<T>> Query(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                return await _DAOEntities.Query(predicate, includes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Récupère toutes les entités de la source de données en tant que requête IQueryable.
        /// </summary>
        /// <returns>Une requête IQueryable de toutes les entités.</returns>
        public virtual async Task<IQueryable<T>> Query()
        {
            try
            {
                return await _DAOEntities.Query();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Récupère de manière asynchrone une entité par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de l'entité à récupérer.</param>
        /// <returns>L'entité récupérée de manière asynchrone.</returns>
        public virtual async Task<T> Get(int? id)
        {
            try
            {
                return await _DAOEntities.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public virtual async Task<T> Get(string id)
        {
            try
            {
                return await _DAOEntities.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Récupère de manière asynchrone toutes les entités de la source de données.
        /// </summary>
        /// <returns>Une collection de toutes les entités récupérées de manière asynchrone.</returns>
        public virtual async Task<IEnumerable<T>> Get()
        {
            try
            {
                return await _DAOEntities.Get();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Ajoute de manière asynchrone une nouvelle entité à la source de données.
        /// </summary>
        /// <param name="entity">L'entité à ajouter.</param>
        public virtual async Task Add(T entity)
        {
            try
            {
                await _DAOEntities.Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Met à jour de manière asynchrone une entité dans la source de données.
        /// </summary>
        /// <param name="entity">L'entité à mettre à jour.</param>
        public virtual async Task Update(T entity)
        {
            try
            {
                await _DAOEntities.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Supprime de manière asynchrone une entité de la source de données.
        /// </summary>
        /// <param name="entity">L'entité à supprimer.</param>
        public virtual async Task Delete(T entity)
        {
            try
            {
                await _DAOEntities.Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Ajoute de manière asynchrone une liste des entités à la source de données.
        /// </summary>
        /// <param name="entities">Liste des entités à ajouter.</param>
        public async Task Add(IEnumerable<T> entities)
        {
            try
            {
                await _DAOEntities.Add(entities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Met à jour de manière asynchrone une liste des entités dans la source de données.
        /// </summary>
        /// <param name="entities">Liste des entités à mettre à jour.</param>
        public async Task Update(IEnumerable<T> entities)
        {
            try
            {
                await _DAOEntities.Update(entities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Supprime de manière asynchrone une liste des entités de la source de données.
        /// </summary>
        /// <param name="entities">Liste des entités à supprimer.</param>
        public async Task Delete(IEnumerable<T> entities)
        {
            try
            {
                await _DAOEntities.Delete(entities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
