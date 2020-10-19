using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.BL.Model
{
    /// <summary>
    ///  Class about gender.
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// Name of gender.
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Gender() { }
        /// <summary>
        /// Create new gender.
        /// </summary>
        /// <param name="name"></param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of the gender can't be empty", nameof(name));
            }
            Name = name;
        }
        /// <summary>
        /// To display simple gender's information
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
