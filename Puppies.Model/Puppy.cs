using Puppies.Model.Base;
using Puppies.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppies.Model
{
    public class Puppy : BaseItem
    {
        public string Name { get; set; }

        public GenderEnum Gender { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public FurColorEnum FurColor { get; set; }

        public int BreedId { get; set; }

        public Breed Breed { get; set; }
    }
}
