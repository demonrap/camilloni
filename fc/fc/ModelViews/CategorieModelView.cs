using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fc.ModelViews
{
    public class CategorieModelView
    {
        public string id_categoria { get; set; }
        public string chiave { get; set; }
        public string descrizione_it { get; set; }
        public string descrizione_en { get; set; }
        public string id_categoria_padre { get; set; }
        public short livello { get; set; }
    }
}