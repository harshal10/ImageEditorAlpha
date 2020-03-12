using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageEditorAlpha.Models;
using Microsoft.AspNetCore.Mvc;
using ImageProcessor;
using System.Drawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace ImageEditorAlpha.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [HttpPost]
        public FileContentResult ImageEditRequest([FromBody] string RequestData)
        {
            //map request to DTO RequestModel
            JObject model= new JObject();

            try
            {
                model = JObject.Parse(RequestData);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }

            RequestModel request = new RequestModel
            {
                ImageData = model["ImageData"].ToString(),
                Operations = model["Operations"].ToObject<List<JObject>>()
            };
            
            //create data stream
            var imageDataByteArray = Convert.FromBase64String(request.ImageData);
 
            var imageDataStream = new MemoryStream(imageDataByteArray);
            imageDataStream.Position = 0;

            //Save edited image result here
            var imageOutStream = new MemoryStream();

            ImageFactory imageFactory = new ImageFactory();

            imageFactory.Load(imageDataStream);            

            foreach (JObject JOp in request.Operations)
            {               
                if (JOp.ContainsKey("Resize"))
                {
                    var JTemp = JOp["Resize"];
                    Resize resize = JTemp.ToObject<Resize>();
                    resize.PerformAction(imageFactory);
                }
                else if (JOp.ContainsKey("Filter"))
                {
                    var JTemp = JOp["Filter"];
                    Filter filter = JTemp.ToObject<Filter>();
                    filter.PerformAction(imageFactory);
                }
                else if (JOp.ContainsKey("Flip"))
                {
                    var JTemp = JOp["Flip"];
                    Flip flip = JTemp.ToObject<Flip>();
                    flip.PerformAction(imageFactory);
                }
                else if (JOp.ContainsKey("Rotate"))
                {
                    var JTemp = JOp["Rotate"];
                    RotateRight rotate = JTemp.ToObject<RotateRight>();
                    rotate.PerformAction(imageFactory);
                }
                else if (JOp.ContainsKey("RotateDegrees"))
                {
                    var JTemp = JOp["RotateDegrees"];
                    RotateDegrees rotateDegrees = JTemp.ToObject<RotateDegrees>();
                    rotateDegrees.PerformAction(imageFactory);
                }
                else if (JOp.ContainsKey("Thumbnail"))
                {
                    var JTemp = JOp["Thumbnail"];
                    Thumbnail thumbnail = JTemp.ToObject<Thumbnail>();
                    thumbnail.PerformAction(imageFactory);
                }
            }
            imageFactory.Save(imageOutStream);

            return File(imageOutStream.ToArray(), "image/png");
        }

        [HttpPost]
        public string test(HttpRequestMessage request)
        {
            var RequestData = request.Content.ReadAsStringAsync().Result;

            string Response = string.Empty;
            JObject model = new JObject();

            try
            {
                model = JObject.Parse(RequestData);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }

            RequestModel Request = new RequestModel
            {
                ImageData = model["ImageData"].ToString(),
            };

            Response = JsonConvert.SerializeObject(Request);

            return Response;
        }

    }
}