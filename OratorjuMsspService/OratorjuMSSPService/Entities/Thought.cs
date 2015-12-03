using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace OratorjuMSSPService.Entities
{
    public class Thought
    {
        public string t_date { get; set; }
        public string t_friendlyDate { get; set; }
        public string t_content { get; set; }
        public string t_image { get; set; }
    }
}