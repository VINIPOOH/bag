using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalamandrBag.animal;

namespace SalamandrBag.place.impl
{
    public class ConcretePlaceOfLiving : IPlace
    {
        private List<IAnimal> _animals;
        private List<AnimalType> _animalTypesWhichCanLiveHere;

        public ConcretePlaceOfLiving(List<AnimalType> animalTypesWhichCanLiveHere)
        {
            _animals = new List<IAnimal>();
            _animalTypesWhichCanLiveHere = animalTypesWhichCanLiveHere;
        }

        public bool AddAnimal(IAnimal animal)
        {
            if (_animalTypesWhichCanLiveHere.Contains(animal.Type))
            {
                _animals.Add(animal);
                return true;
            }
            return false;
        }

        public string VoiceToConcreteAnimal(string animalName)
        {          
            IAnimal concreteAnimal = _animals.Where(animal => animal.Name == animalName).FirstOrDefault();

            return concreteAnimal.CommandVoice();
        }

        public StringBuilder VoiceToAllAnimals()
        {
            StringBuilder animalSays = new StringBuilder();

            _animals.ForEach(animal => animalSays.Append(animal.CommandVoice()));

            return animalSays;
        }

        public int GetTotalFoodWeightPerDay()
        {
            return _animals.Sum(animal => animal.WeightOfFoodPerDay);
        }

        public float GetAverageFoodWeightPerAnimal()
        {
            return (float)_animals.Average(animal => animal.WeightOfFoodPerDay);
        }

        public int CountAnimals()
        {
            return _animals.Count;
        }
    }
}