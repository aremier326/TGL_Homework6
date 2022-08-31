using Puppies.Model.Base;
using Puppies.Model.Enums;


namespace Puppies.Model
{
    public class Puppy : BaseItem
    {
        public string Name { get; set; }

        public GenderEnum Gender { get; set; }

        public int Age { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public FurColorEnum FurColor { get; set; }

        public int BreedId { get; set; }

        public Breed Breed { get; set; }
    }
}
