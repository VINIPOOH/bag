using System;

namespace SalamandrBag.animal
{
    public interface IAnimal
    {
        String Name { get; }
        int WeightOfFoodPerDay { get; }
        AnimalType GetAnimalType();
        String CommandVoice();
    }
}