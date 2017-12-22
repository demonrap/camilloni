namespace fc.ModelViews
{
    public class FilterModelView
    {
        public int page_number { get; set; }
        public int rec_number { get; set; }
        public int rec_x_pagina { get; set; }
        public double pag_number { get; set; }

        public string cat { get; set; }
        public string key { get; set; }
        public bool online { get; set; }
    }
}