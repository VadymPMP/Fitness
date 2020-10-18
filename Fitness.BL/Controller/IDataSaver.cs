using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.BL.Controller
{
    public interface IDataSaver<T> where T: class
    {
        void Save(T item);

        List<T> Load();
    }
}
