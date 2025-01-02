using System.Collections.Generic;

namespace BackendAPI.Entities
{
    public class Mahalle
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int IlceId { get; set; }

        public Ilce Ilce { get; set; }
        public ICollection<Tasinmaz> Tasinmazlar { get; set; }
    }
}
