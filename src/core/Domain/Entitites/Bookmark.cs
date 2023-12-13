using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitites
{
    public class Bookmark 
    {
        public Guid ArtworkId { get; set; }
        public virtual Artwork Artwork { get; set; } = default!;
        public Guid CollectionId { get; set; }
        public virtual Collection Collection { get; set; } = default!;
    }
}
