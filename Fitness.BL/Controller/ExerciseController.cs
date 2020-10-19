using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.BL.Controller
{
    [Serializable]
    /// <summary>
    /// Exercises controller
    /// </summary>
    public class ExerciseController : ControllerBase
    {

        /// <summary>
        /// Our current user.
        /// </summary>
        private readonly User user;
        /// <summary>
        /// List of exercises
        /// </summary>
        public List<Exercise> Exercises { get;  }
        /// <summary>
        /// List of activities
        /// </summary>
        public List<Activity> Activities { get; }
        /// <summary>
        /// Create a new ExerciseController.
        /// </summary>
        /// <param name="user"></param>
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            Exercises = GetAllExercises();

            Activities = GetAllActivities();
        }


        /// <summary>
        /// Adding information about food and its weight
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
                
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
                
            }
            Save();
        }

        /// <summary>
        /// Get the saved activity's list.
        /// </summary>
        /// <returns>List of Activities.</returns>
        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }
        /// <summary>
        /// Get the saved exercise's list.
        /// </summary>
        /// <returns>List of Exercises.</returns>
        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }
        /// <summary>
        /// Save data about Activities and exercises.
        /// </summary>
        private void Save()
        {
            Save(Exercises);
            Save(Activities);
            
        }
    }
}
