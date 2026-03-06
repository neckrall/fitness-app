using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Services
{
    internal class DatabaseSaver : IDataSaver
    {
        public void Save<T>(List<T> data) where T : class
        {
            using (var db = new FitnessAppDbContext())
            {
                db.Set<T>().AddRange(data);
                db.SaveChanges();
            }
        }

        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessAppDbContext())
            {
                var result = db.Set<T>().Where(t => true).ToList();
                return result;
            }
        }
    }
}
