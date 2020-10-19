using Fitness.BL.Model;
using System;
using System.Linq;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Fitness.BL.Controller
{
    public class DatabaseDataSaver : IDataSaver 
    {
        
        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                var resault = db.Set<T>().Where(t => true).ToList();
                return resault;
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
