using System.Text;

namespace e_School_Register_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OnButtonSaveClick(object sender, EventArgs e)
        {
            string studentName = textBoxFullName.Text;
            string studentClass = comboBoxClass.Text;
            string studentMarks = richTextBoxStudentMarks.Text;

            string filePath = $"../../../students_{studentClass}.txt";
            StreamWriter writer = new StreamWriter(filePath, true, Encoding.Unicode);
            using (writer)
            {
                writer.WriteLine("име: " + studentName);
                writer.WriteLine(studentMarks);
            }

            textBoxFullName.Text = string.Empty;
            comboBoxClass.Text = string.Empty;
            richTextBoxStudentMarks.Text = string.Empty;

            comboBoxClass.Text = studentClass;
            OnClassChanged(sender, e);
        }

        private void OnClassChanged(object sender, EventArgs e)
        {
            listBoxStudents.Items.Clear();
            string selectedClass = comboBoxStudentsClass.Text;
            string path = $"../../../students_{selectedClass}.txt";
            StreamReader reader = new StreamReader(path, Encoding.Unicode);
            using (reader)
            {
                string line = reader.ReadLine();
                while(line != null)
                {
                    if(line.StartsWith("име: "))
                    {
                        line = line.Substring(5);
                        listBoxStudents.Items.Add(line);
                    }                    
                    line = reader.ReadLine();
                }
            }
        }
    }
}
