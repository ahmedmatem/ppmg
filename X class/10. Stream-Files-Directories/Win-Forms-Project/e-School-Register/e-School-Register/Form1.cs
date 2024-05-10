using System.Text;

namespace e_School_Register
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

            comboBoxStudentClass.Text = studentClass;
            OnClassChanged(sender, e);
        }

        private void OnClassChanged(object sender, EventArgs e)
        {
            string selectedClass = comboBoxStudentClass.Text;
            string pathFile = "../../../students_" + selectedClass + ".txt";
            try
            {
                StreamReader reader = new StreamReader(pathFile, Encoding.Unicode);
                using (reader)
                {
                    listBoxStudents.Items.Clear();
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        if (line.StartsWith("име"))
                        {
                            string studentName = line.Split(": ")[1];
                            listBoxStudents.Items.Add(studentName);
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                listBoxStudents.Items.Clear();
                listBoxStudents.Items.Add("Все още няма добавен ученик.");
            }
        }

        private void listBoxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StudentsListDoubleClick(object sender, EventArgs e)
        {
            StringBuilder message = new StringBuilder();
            string studentClass = comboBoxStudentClass.Text;
            string studentName = listBoxStudents.SelectedItem.ToString();

            message.AppendLine(studentName);
            message.AppendLine(new string('о', studentName.Length));

            string path = $"../../../students_{studentClass}.txt";
            StreamReader reader = new StreamReader(path, Encoding.Unicode);
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    if(line == $"име: {studentName}")
                    {
                        line = reader.ReadLine();
                        while(line != null && !line.StartsWith("име: "))
                        {
                            message.AppendLine(line);
                            line = reader.ReadLine();
                        }
                    }
                    line = reader.ReadLine();
                }
            }

            MessageBox.Show(message.ToString());
        }
    }
}
