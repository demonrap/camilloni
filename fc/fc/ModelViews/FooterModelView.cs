using fc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fc.ModelViews
{
    public class FooterModelView
    {
        public FooterModelView()
        {
            this.scelti = new List<FeaturedModelView>();
            this.social = new List<sy_social>();
        }

        public string chisiamo { get; set; }
        public string azienda { get; set; }
        public virtual IList<FeaturedModelView> scelti { get; set; }
        public virtual IList<sy_social> social { get; set; }
    }
}