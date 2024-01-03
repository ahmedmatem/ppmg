using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer
{
    internal class FileRenderer : IRenderer
    {
        private string path;
        private IRenderer renderer;

        public FileRenderer(string path)
        {
            this.path = path;
        }

        public void Write(string text)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(text, true);
            }
        }

        public void WriteLine(string text)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(text, true);
            }
        }
    }
}
