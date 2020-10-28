using System;
using System.Collections.Generic;
using System.Text;
using SalamandrBag.animal;
using SalamandrBag.animal.impl;

namespace SalamandrBag.place.impl
{
    public class ConcretePlaceOfLiving:IPlace
    {
        private List<IAnimal> Animals = new List<IAnimal>();
        private List<AnimalType> AnimalTypesWhichCanLiveHere;

        public ConcretePlaceOfLiving(List<AnimalType> animalTypesWhichCanLiveHere)
        {
            AnimalTypesWhichCanLiveHere = animalTypesWhichCanLiveHere;
        }

        public bool AddAnimal(IAnimal animal)
        {
            if (AnimalTypesWhichCanLiveHere.Contains(animal.GetAnimalType()))
            {
                Animals.Add(animal);
                return true;
            }
            return false;
        }

        public string VoiceToConcreteAnimal(string animalName)
        {
            String animalSays = null;
            foreach (var animal in Animals)
            {
                if (animal.GetName()==animalName)
                {
                    animalSays = animal.CommandVoice();
                    break;
                }
            }
            return animalSays;
        }

        public StringBuilder VoiceToAllAnimals()
        {
            StringBuilder animalSays = new StringBuilder();
            foreach (var animal in Animals)
            {
                animalSays.Append(animal.CommandVoice());
            }
            return animalSays;
        }

        public int GetTotalFoodWeightPerDay()
        {
            int totalFoodWeight = 0;
            foreach (var animal in Animals)
            {
                totalFoodWeight += animal.GetWeightOfFoodPerDay();
            }
            return totalFoodWeight;
        }

        public float GetAverageFoodWeightPerAnimal()
        {
            int totalFoodWeight = 0;
            foreach (var animal in Animals)
            {
                totalFoodWeight += animal.GetWeightOfFoodPerDay();
            }
            return totalFoodWeight/Animals.Count;
        }

        public int CountAnimals()
        {
            return Animals.Count;
        }
    }
}