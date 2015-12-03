using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OratorjuMSSPService.Entities
{
    public class Article
    {
        public DateTime a_date { get; set; }
        public String a_friendlyDate { get; set; }
        public String a_content { get; set; }
    }
}