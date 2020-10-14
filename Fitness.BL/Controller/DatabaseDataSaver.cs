using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.BL.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        public T Load<T>(string filename)
        {
            throw new NotImplementedException();
        }

        public void Save(string filename, object item)
        {
            throw new NotImplementedException();
        }
    }
}
