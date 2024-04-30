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
                writer.WriteLine(studentName);
                writer.WriteLine(studentMarks);
            }

            textBoxFullName.Text = string.Empty;
            comboBoxClass.Text = string.Empty;
            richTextBoxStudentMarks.Text = string.Empty;
        }
    }
}
