using Fitness.BL.Model;
using System;
using System.Linq;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Fitness.BL.Controller
{
    public class DatabaseDataSaver<T> : IDataSaver<T> where T: class
    {
        
        public List<T> Load()
        {
            using (var db = new FitnessContext())
            {
                var resault = db.Set<T>().Where(l => true).ToList();
                return resault;
            }
        }

        public void Save(T item)
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().Add(item);
                db.SaveChanges();
            }
        }
    }
}
