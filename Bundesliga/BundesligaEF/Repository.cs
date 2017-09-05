﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BundesligaEF
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity :class
    {
        protected BundesligaContext _context;
        protected DbSet<TEntity> _dbset;

        public Repository(BundesligaContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }
        public void Delete(int id)
        {
            var entityToDelete=_dbset.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbset.AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbset.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbset.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {            
            _context.Update(entity);
        }
    }
}
