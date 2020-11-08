using System.Text;
using SalamandrBag.animal;

namespace SalamandrBag.place
{
    public interface IPlace
    {
        bool AddAnimal(IAnimal animal);
        string VoiceToConcreteAnimal(string animalName);
        StringBuilder VoiceToAllAnimals();
        int GetTotalFoodWeightPerDay();
        float GetAverageFoodWeightPerAnimal();
        int CountAnimals();
    }
}