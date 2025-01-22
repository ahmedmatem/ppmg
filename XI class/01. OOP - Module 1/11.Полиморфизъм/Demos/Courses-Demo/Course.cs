using System.Runtime.InteropServices;

namespace Courses_Demo
{
    internal abstract class Course
    {
        // Abstract methods
        public abstract int GetDuration();
        public abstract string GetLevel();

        // Virtual methods
        public virtual string GetDescription()
        {
            return $"This is a {GetType().Name} course.";
        }
    }
}
