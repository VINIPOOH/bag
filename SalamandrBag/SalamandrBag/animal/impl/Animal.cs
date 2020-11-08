namespace SalamandrBag.animal.impl
{
    public class Animal : IAnimal
    {
        private AnimalState _animalState;

        public int WeightOfFoodPerDay { get; }

        public string Name { get; }

        public AnimalType Type => _animalState.Type;

        public Animal(string name, int weightOfFoodPerDay, AnimalState animalState)
        {
            _animalState = animalState;

            Name = name;
            WeightOfFoodPerDay = weightOfFoodPerDay;            
        }

        public string CommandVoice()
        {
            return _animalState.Speech + Name;
        }
    }
}