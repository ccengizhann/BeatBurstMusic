using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBurstMusic.Domain.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<ProductGetAllCategoryDto> Categories { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}