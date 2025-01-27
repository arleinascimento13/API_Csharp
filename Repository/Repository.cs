using Infra;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repository
{
    //
    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly APIDBContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(APIDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            _dbSet.Remove(user);
            _context.SaveChanges();
        }

        public List<T> Get()
        {
            return _dbSet.ToList();
            
        }

        public T GetById(int id)
        {
            var user = _dbSet.Find(id);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Patch(int id)
        {
            // depois eu faÇo esse carlaho
        }

        public void Post(T user)
        {
            _dbSet.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id)
        {
            var user = GetById(id);
            _context.SaveChanges();
        }
    }
}
