namespace GraphicalUserInterface
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class SimpleForm : Form
    {
        private const string VideoPath = "SOLID-Logger.mp4";
        private const string DestinationPath = "Pieces";
        private const int BufferLength = 4096;

        public SimpleForm()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            // Blocks UI until completion
            // Slice(VideoPath, DestinationPath, 5); 
            SliceAsync(VideoPath, DestinationPath, 5);
        }

        private async void SliceAsync(string sourceFile, string destinationPath, int parts)
        {
            var label = this.Controls["result"] as Label;
            label.Text = "Slicing...";

            await Task.Run(() =>
            {
                Slice(sourceFile, destinationPath, parts);
            });

            label.Text = "Finished";
        }

        private void Slice(string sourceFile, string destinationPath, int parts)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                FileInfo fileInfo = new FileInfo(sourceFile);
                long totalLength = source.Length;
                long partLength = (totalLength/parts) + 1;
                long currentByte = 0;
                for (int i = 1; i <= parts; i++)
                {
                    string filePath = string.Format("{0}/Part-{1}.{2}",
                        destinationPath, i, fileInfo.Extension);

                    using (var destination = new FileStream(filePath, FileMode.Create))
                    {
                        byte[] buffer = new byte[BufferLength];
                        while (currentByte <= partLength*i)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);
                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }
            }
        }
    }
}
