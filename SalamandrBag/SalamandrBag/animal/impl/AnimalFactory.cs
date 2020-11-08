using System.Collections.Generic;
using SalamandrBag.animal.exeption;

namespace SalamandrBag.animal.impl
{
    public class AnimalFactory:IAnimalFactory
    {
        private const string LICHURKA_SPEECH = "I am lichurka said ";
        private const string COMUFLOR_SPEECH = "I am comuflor said ";
        private const string OKKAM_SPEECH = "I am okkam said ";

        private Dictionary<AnimalType,AnimalState>  _animalStates = new Dictionary<AnimalType,AnimalState>();  
        
        public IAnimal CreateAnimal(string animalName, int foodWeightPerDay, AnimalType type)
        {
            if (_animalStates.ContainsKey(type))
            {
                return new Animal(animalName, foodWeightPerDay, _animalStates[type]);
            }

            switch (type)
            {
                case AnimalType.OKKAM:
                    _animalStates[type] = new AnimalState(type, OKKAM_SPEECH);
                    break;
                case AnimalType.LICHURKA:
                    _animalStates[type] = new AnimalState(type, LICHURKA_SPEECH);
                    break;
                case AnimalType.COMUFLOR:
                    _animalStates[type] = new AnimalState(type, COMUFLOR_SPEECH);
                    break;
            }

            if (!_animalStates.ContainsKey(type))
            {
                throw new NoSuchAnimalTypeException();
            }

            return new Animal(animalName, foodWeightPerDay, _animalStates[type]);
        }
    }
}