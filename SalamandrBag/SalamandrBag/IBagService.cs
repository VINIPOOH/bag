using SalamandrBag.animal;

namespace SalamandrBag
{
    public interface IBagService
    {
        void SetDay();
        void SetNight();
        int CountAllAnimals();
        bool AddAnimal(IAnimal animal);
        string CommandVoiceToConcreteAnimal(string animalName);
        string CommandVoiceToAllAnimals();
        int GetTotalFoodWeightPerDay();
        float GetAverageFoodWeightPerAnimal();
        bool AnimalTryJumpIntoBag();
    }
}