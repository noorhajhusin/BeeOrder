using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

static class ExtensionMethods
{
    public static System.ServiceModel.Channels.Message GetJsonStream(this object obj)
    {
        //Serialize JSON.NET
        string jsonSerialized = new JavaScriptSerializer().Serialize(obj);

        //Create memory stream
        MemoryStream memoryStream = new MemoryStream(new UTF8Encoding().GetBytes(jsonSerialized));

        //Set position to 0
        memoryStream.Position = 0;

        //return Message
        return WebOperationContext.Current.CreateStreamResponse(memoryStream, "application/json");
    }
}