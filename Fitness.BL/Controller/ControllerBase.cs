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
        /// <summary>
        /// Template for saving information.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="item"></param>
        protected void Save(string filename, object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }

        }
        /// <summary>
        /// Template for loading information.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <returns></returns>
        protected T Load<T>(string filename)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }

        }
    }
}
