using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebDemoApi.DataAccessLayer
{
    public class DbEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class JapaneseWordDbContext : DbContext, IDisposable
    {
        public virtual IDbSet<DbEntity> DbEntities { get; set; }
    }

    public class Processor
    {
        private readonly JapaneseWordDbContext _dbContext;

        public Processor(JapaneseWordDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbEntity Find(int id)
        {
            return _dbContext.DbEntities.FirstOrDefault(dbEntity => dbEntity.Id == id);
        }


    }
}