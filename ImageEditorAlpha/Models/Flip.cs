using ImageProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageEditorAlpha.Models
{
    public class Flip : Action
    {
        public bool FlipVertical { get; set; }

        public ImageFactory PerformAction(ImageFactory image)
        {
           return image.Flip(this.FlipVertical);
        }
    }
}
