using System;

namespace SalamandrBag.animal.impl
{
    public class Animal : IAnimal
    {
        public String Name { get; }
        public int WeightOfFoodPerDay { get; }
        private AnimalState animalState;

        public Animal(string name, int weightOfFoodPerDay, AnimalState animalState)
        {
            this.Name = name;
            this.WeightOfFoodPerDay = weightOfFoodPerDay;
            this.animalState = animalState;
        }


        public AnimalType GetAnimalType()
        {
            return animalState.GetType();
        }

        public String CommandVoice()
        {
            return animalState.GetSpeech() + Name+ ";  ";
        }
    }
}