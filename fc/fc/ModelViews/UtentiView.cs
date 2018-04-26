using System.Collections.Generic;

namespace fc.ModelViews
{
    public class UtentiView
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public int AccessFailedCount { get; set; }
        public bool LockoutEnabled { get; set; }
        public string Roles { get; set; }
    }

    public class EditRuoliView
    {
        public EditRuoliView()
        {
            this.ruoli = new List<RuoliView>();
        }
        public string Id { get; set; }
        public string Email { get; set; }
        public virtual IList<RuoliView> ruoli { get; set; }
    }

    public class RuoliView
    {
        public string Name { get; set; }
        public bool check { get; set; }
    }
}