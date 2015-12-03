using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OratorjuMSSPService
{/*
    /// <summary>
    /// Summary description for ThoughtHandler
    /// </summary>
    public class ThoughtHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int displayImgId = Convert.ToInt32(String.Format("{0:yyyyMMdd}", context.Request.QueryString["id_Image"]));
            context.Response.ContentType = "image/jpeg";
            Stream st = (UtilsThought.getThoughtById(displayImgId).t_image);
            byte[] buffer = new byte[4096];
            int byteSeq = st.Read(buffer, 0, 4096);
            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = st.Read(buffer, 0, 4096);
            }
        }
        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
      
    }
  */
}