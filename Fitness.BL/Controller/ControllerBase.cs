using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Fitness.BL.Controller
{

    /// <summary>
    /// Basic controller abstract class
    /// </summary>
    public abstract class ControllerBase
    {

        protected IDataSaver saver = new SerializeDataSaver();


        /// <summary>
        /// Template for saving information.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="item"></param>
        protected void Save(string filename, object item)
        {
            saver.Save(filename, item);
        }
        /// <summary>
        /// Template for loading information.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <returns></returns>
        protected T Load<T>(string filename)
        {

            return saver.Load<T>(filename);
        }
    }
}
