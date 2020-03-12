using ImageProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageEditorAlpha.Models
{
    public class RotateRight : Action
    {
        public bool Right { get; set; }

        public ImageFactory PerformAction(ImageFactory image)
       {
            int degrees = 270;
            if (Right)
            {
                degrees = 90;
            }

            image.Rotate(degrees);

            return image;
       }


    }
}
