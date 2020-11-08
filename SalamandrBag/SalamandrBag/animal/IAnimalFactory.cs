namespace SalamandrBag.animal
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string animalName, int foodWeightPerDay, AnimalType type);
    }
}