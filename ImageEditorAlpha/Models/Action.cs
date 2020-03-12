using ImageProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageEditorAlpha.Models
{
    interface Action
    {
       ImageFactory PerformAction(ImageFactory image);

    }
}
