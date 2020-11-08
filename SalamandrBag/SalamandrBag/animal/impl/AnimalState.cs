namespace SalamandrBag.animal
{
    public class AnimalState
    {
        public AnimalType Type { get; }
        public string Speech { get; }

        public AnimalState(AnimalType animalType, string speech)
        {
            Type = animalType;
            Speech = speech;
        }
    }
}