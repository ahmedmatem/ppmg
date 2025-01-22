
using System.Text;

namespace Courses_Demo
{
    internal class ProgrammingCourse : Course
    {
        // fields
        private string language;
        private bool hasProject;
        private int duration;
        private string level;

        // constructor
        public ProgrammingCourse(
            string lang, 
            bool _hasProject, 
            int _duration,
            string _level)
        {
            language = lang;
            hasProject = _hasProject;
            duration = _duration;
            level = _level;
        }

        public override int GetDuration()
        {
            return duration;
        }

        public override string GetLevel()
        {
            return level;
        }

        public override string GetDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.GetDescription());
            sb.AppendLine($"The course language is {language}.");
            if(hasProject)
            {
                sb.AppendLine($"The course has a final project to do.");
            }
            else
            {
                sb.AppendLine($"The course has NO a final project to do.");
            }

            return sb.ToString();
        }
    }
}
