namespace SalamandrBag.animal
{
    public interface IAnimal
    {
        AnimalType Type { get; }

        int WeightOfFoodPerDay { get; }

        string Name { get; }

        string CommandVoice();
    }
}