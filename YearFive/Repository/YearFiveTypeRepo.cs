using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YearFive.Contracts;
using YearFive.Data;

namespace YearFive.Repository
{
    public class YearFiveTypeRepo : IYearFiveRepository
    {
        private readonly ApplicationDbContext _db;

        public YearFiveTypeRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(YearFiveType entity)
        {
            _db.yearFiveTypes.Add(entity);
            return Save();
        }

        public bool Delete(YearFiveType entity)
        {
            _db.yearFiveTypes.Remove(entity);
            return Save();
        }

        public ICollection<YearFiveType> FindAll()
        {
            var friendss = _db.yearFiveTypes.ToList();
            return friendss;
        }

        public YearFiveType FindById(int id)
        {
            var friendss = _db.yearFiveTypes.Find(id);
            return friendss;
        }

        public bool isExists(int id)
        {
            var exists = _db.yearFiveTypes.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(YearFiveType entity)
        {
            _db.yearFiveTypes.Update(entity);
            return Save();
        }
    }
}
