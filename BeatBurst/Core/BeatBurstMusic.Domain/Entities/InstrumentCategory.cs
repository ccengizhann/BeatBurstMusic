using BeatBurstMusic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBurstMusic.Domain.Entities
{
    public class InstrumentCategory : ICreatedOn
    {
        public Guid InstrumentId { get; set; }
        public Instrument Instrument { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public string? CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
