using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageEditorAlpha.Models
{
    public class RequestModel
    {
        public string ImageData { get; set; }
        public List<JObject> Operations { get; set; }
    }
}
