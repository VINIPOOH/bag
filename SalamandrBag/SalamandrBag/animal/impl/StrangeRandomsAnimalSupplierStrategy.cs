using System;

namespace SalamandrBag.animal.impl
{
    public class StrangeRandomsAnimalSupplierStrategy : IAnimalSupplierStrategy
    {
        private const int DEFAULTS_AMOUNT_FOOD_PER_DAY = 5;
        private const string DEFAULTS_ANIMAL_NAME = "animal";

        private IAnimalFactory _animalFactory;
        private int _animalCounter;
        
        public IAnimal GetAnimal()
        {
            return _animalFactory.CreateAnimal(
                GenerateAnimalName(),
                GenerateFoodPerDay(),
                ChooseAnimalType());          
        }

        private string GenerateAnimalName()
        {
            return DEFAULTS_ANIMAL_NAME + _animalCounter++;
        }

        private int GenerateFoodPerDay()
        {
            return DEFAULTS_AMOUNT_FOOD_PER_DAY;
        }

        private AnimalType ChooseAnimalType()
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 100);

            if (0 <= value && value < 40)
            {
                return AnimalType.LICHURKA;
            }
            else if (40 <= value && value < 79)
            {
                return AnimalType.COMUFLOR;
            }
            else if (80 <= value && value < 99)
            {
                return AnimalType.OKKAM;
            }

            return default;
        }
    }
}