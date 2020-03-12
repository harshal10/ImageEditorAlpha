using ImageProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageEditorAlpha.Models
{
    public class Resize : Action
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ImageFactory PerformAction(ImageFactory image)
        {
            Size size = new Size(this.Width, this.Height);
            return image.Resize(size);
        }
    }
}
