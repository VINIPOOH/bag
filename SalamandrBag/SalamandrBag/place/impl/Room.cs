using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalamandrBag.animal;

namespace SalamandrBag.place.impl
{
    public class Room : IPlace
    {
        private List<IPlace> _places;
        private List<AnimalType> _animalTypesWhichCanPathHere;

        public Room(List<IPlace> places, List<AnimalType> animalTypesWhichCanPathHere)
        {
            _places = places;
            _animalTypesWhichCanPathHere = animalTypesWhichCanPathHere;
        }

        public void AddPlace(IPlace place)
        {
            _places.Add(place);
        }

        public bool AddAnimal(IAnimal animal)
        {
            if (!_animalTypesWhichCanPathHere.Contains(animal.Type))
            {
                return false;
            }

            foreach (var place in _places)
            {
                if (place.AddAnimal(animal))
                {
                    return true;
                }
            }
            
            return false;
        }

        public string VoiceToConcreteAnimal(string animalName)
        {
            string animalSays = null;

            foreach (var place in _places)
            {
                animalSays = place.VoiceToConcreteAnimal(animalName);
                if (animalSays != null)
                {
                    break;
                }
            }

            return animalSays;
        }

        public StringBuilder VoiceToAllAnimals()
        {
            StringBuilder animalSays = new StringBuilder();

            _places.ForEach(place => animalSays.Append(place.VoiceToAllAnimals()));

            return animalSays;
        }

        public int GetTotalFoodWeightPerDay()
        {
            return _places.Sum(place => place.GetTotalFoodWeightPerDay());
        }

        public float GetAverageFoodWeightPerAnimal()
        {
            return (float)_places.Average(place => place.GetAverageFoodWeightPerAnimal());
        }

        public int CountAnimals()
        {
            return _places.Sum(place => place.CountAnimals());
        }
    }
}