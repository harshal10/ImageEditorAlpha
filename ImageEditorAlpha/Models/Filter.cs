using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageProcessor;
using ImageProcessor.Imaging.Filters.Photo;


namespace ImageEditorAlpha.Models
{
    public class Filter : Action
    {
        
        private IMatrixFilter matrix = MatrixFilters.BlackWhite;
        string FilterType { get; set; }
        
        public ImageFactory PerformAction(ImageFactory image)
        {
            return image.Filter(matrix);
        }
    }
}
