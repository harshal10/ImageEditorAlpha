using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using ImageProcessor;

namespace ImageEditorAlpha.Models
{
    public class Thumbnail : Action
    {
        string Type { get; set; }

        public ImageFactory PerformAction(ImageFactory image)
        {
            Size size = new Size(210, 89);
            return image.Resize(size);
        }
    }
}
