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
        /// <summary>
        /// Start performing exercises
        /// </summary>
        public DateTime Start { get;}
        /// <summary>
        /// Finish performing exercises
        /// </summary>
        public DateTime Finish { get;}
        /// <summary>
        /// Type of activity
        /// </summary>
        public Activity Activity { get;}
        /// <summary>
        /// Our current user
        /// </summary>
        public User User { get;}
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
