using BeatBurstMusic.Domain.Common;
using BeatBurstMusic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBurstMusic.Domain.Entities
{
    public class Instrument : EntityBase<Guid>
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public decimal Price { get; set; }
        public Color Color { get; set; }
        public string Barcode { get; set; }
        public string PictureUrl { get; set; }
        public ICollection<InstrumentCategory> InstrumentCategories { get; set; }

    }
}
