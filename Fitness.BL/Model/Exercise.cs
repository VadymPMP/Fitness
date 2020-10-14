using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Class about exercises
    /// </summary>
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }
        /// <summary>
        /// Start performing exercises
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// Finish performing exercises
        /// </summary>
        public DateTime Finish { get; set; }
        /// <summary>
        /// Type of activity
        /// </summary>
        /// 
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        /// <summary>
        /// Our current user
        /// </summary>
        /// 
        public int UserId { get; set; }
        public virtual User User { get; set; }
        /// <summary>
        /// Creating the new Exercise
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <param name="activity"></param>
        /// <param name="user"></param>
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            // Exception
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
