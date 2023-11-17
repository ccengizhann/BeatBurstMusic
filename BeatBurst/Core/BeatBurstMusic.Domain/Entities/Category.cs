using BeatBurstMusic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBurstMusic.Domain.Entities
{
    public class Category : EntityBase<Guid>
    {
        public string Name { get; set; }

        public ICollection<InstrumentCategory> InstrumentCategories { get; set; }

        // dbContext.Categories.Include(x=>x.Products).FirstOrDefaultAsync(x=>x.Id == 12345);

        // category.Products
    }
}
