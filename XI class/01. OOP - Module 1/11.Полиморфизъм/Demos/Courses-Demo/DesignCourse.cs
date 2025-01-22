using System.Text;

namespace Courses_Demo
{
    internal class DesignCourse : Course
    {
        // fields
        private string softwareUsed;
        private bool includesCertification;
        private int duration;
        private string level;

        // constructor
        public DesignCourse(
            string software,
            bool hasCertification,
            int duration,
            string level)
        {
            softwareUsed = software;
            includesCertification = hasCertification;
            this.duration = duration;
            this.level = level;
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
            sb.AppendLine($"The course uses {softwareUsed} software.");
            if(includesCertification)
            {
                sb.AppendLine("The coures has certification.");
            }
            else
            {
                sb.AppendLine("The coures hasn't certification.");
            }

            return sb.ToString();
        }
    }
}
