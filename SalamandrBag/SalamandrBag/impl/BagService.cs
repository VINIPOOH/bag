using SalamandrBag.animal;
using SalamandrBag.exeption;
using SalamandrBag.place;

namespace SalamandrBag.impl
{
    public class BagService : IBagService
    {
        private bool isDay;

        private IPlace _place;        
        private IAnimalSupplierStrategy _animalSupplierStrategy;

        public void SetDay()
        {
            isDay = true;
        }

        public void SetNight()
        {
            isDay = false;
        }

        public BagService(IPlace place, IAnimalSupplierStrategy animalSupplierStrategy)
        {
            isDay = true;

            _place = place;
            _animalSupplierStrategy = animalSupplierStrategy;
        }

        public int CountAllAnimals()
        {
            return _place.CountAnimals();
        }

        public bool AddAnimal(IAnimal animal)
        {
            return _place.AddAnimal(animal);
        }

        public string CommandVoiceToConcreteAnimal(string animalName)
        {
            return _place.VoiceToConcreteAnimal(animalName);
        }

        public string CommandVoiceToAllAnimals()
        {
            if (!isDay)
            {
                throw new CallAllAnimalsAtNightException();
            }
            return _place.VoiceToAllAnimals().ToString();
        }

        public int GetTotalFoodWeightPerDay()
        {
            return _place.GetTotalFoodWeightPerDay();
        }

        public float GetAverageFoodWeightPerAnimal()
        {
            return _place.GetAverageFoodWeightPerAnimal();
        }

        public bool AnimalTryJumpIntoBag()
        {
            return _place.AddAnimal(_animalSupplierStrategy.GetAnimal());;
        }
    }
}