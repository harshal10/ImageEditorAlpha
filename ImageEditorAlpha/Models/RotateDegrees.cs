using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageProcessor;

namespace ImageEditorAlpha.Models
{
    public class RotateDegrees : Action
    {
        public int Degrees { get; set; }
        public ImageFactory PerformAction(ImageFactory image)
        {
           return image.Rotate(Degrees);
        }
    }
}
