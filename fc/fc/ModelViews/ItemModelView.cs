namespace fc.ModelViews
{
    public class ItemModelView
    {
        public string id_articolo { get; set; }
        public string articolo { get; set; }
        public string descrizione { get; set; }
        public string descrizione_it { get; set; }
        public string descrizione_en { get; set; }
        public string data_pubblicazione { get; set; }
        public decimal prezzo_di_vendita { get; set; }
        public decimal prezzo_richiesto { get; set; }
        public string valuta { get; set; }
        public string id_utente { get; set; }
        public bool online { get; set; }
        public bool venduto { get; set; }        
        public string anno { get; set; }
        public string produttore { get; set; }
        public string peso { get; set; }
        public string ore { get; set; }
        public string categoria { get; set; }
        public string id_categoria { get; set; }
        public string conta_visite { get; set; }
        public string conta_img { get; set; }
        public string img { get; set; }
    }
}