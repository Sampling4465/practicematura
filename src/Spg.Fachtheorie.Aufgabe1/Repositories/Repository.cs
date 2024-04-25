using Microsoft.EntityFrameworkCore;
using Spg.Fachtheorie.Aufgabe1.Infrastructure;
using Spg.Fachtheorie.Aufgabe1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Fachtheorie.Aufgabe1.Repositories
{
    public class Repository<Entity,Key> where Entity : class, BaseInterface<Key>
    {
        // TODO: DBContext mittels DependencyInjection aktivieren
        private InnoLabContext _dbContext;
        protected readonly DbSet<Entity> _dbSet;

        public Repository(InnoLabContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Entity>();
        }

        public void Deleate(Key Id)
        {

            _dbSet.Remove(this.Read(Id));
            _dbContext.SaveChanges();


        }
        public void Create(BaseInterface<Key> newEntity)
        {

            _dbContext.Add(newEntity);
            _dbContext.SaveChanges();

        }
        public Entity Read(Key Id)
        {

            return _dbSet.FirstOrDefault(a => a.Id.Equals(Id));

        }
        public void Update(BaseInterface<Key> newEntity)
        {

            _dbContext.Update(newEntity);
            _dbContext.SaveChanges();

        }
    }
}
