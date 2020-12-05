﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
 using SalamandrBag;
 using SalamandrBag.animal;
 using SalamandrBag.animal.impl;
 using SalamandrBag.exeption;
 using SalamandrBag.impl;
 using WEB.Models;

namespace WEB.Controllers
{
    
    public class BagController : Controller
    {
        private readonly IBagService bagService;
        private readonly IAnimalFactory animalFactory;
        private static readonly string ModelInfo = "Welcome";
        private static readonly string ViewName = "Index";
        private static readonly string AnimalWasAddedSuccessfully = "Animal was added successfully";
        private static readonly string ThereIsNoPlaceForAnimalSuchType = "There is no place for animal such type";
        private static readonly string AnimalJumpedSuccessfully = "Animal jumped successfully";
        private static readonly string ThereIsNoPlaceForJumpedAnimalType = "There is no place for jumped animal type";
        private static readonly string NowIsDayInBag = "Now is day in bag";
        private static readonly string NowIsNightInBag = "Now is night in bag";
        private static readonly string AmountAnimalsIs = "Amount animals is = ";
        private static readonly string AverageFoodWeightPerAnima = "Average Food Weight Per Animal = ";
        private static readonly string TotalFoodWeightPerDayOnAnimal = "Total Food Weight Per Day On Animal = ";
        private static readonly string AnimalsSays = "Animals says = ";
        private static readonly string YouCantCallAllAnimalsAtNight = "You cant call all animals at night";
        private static readonly string YouCalledAnimalWithName = "You called animal with name = ";
        private static readonly string AndHear = " and hear - ";

        public BagController(IBagService bagService, IAnimalFactory animalFactory)
        {
            this.bagService = bagService;
            this.animalFactory = animalFactory;
        }

        public IActionResult Index(BagWebConsoleModel model)
        {
            model.Info = ModelInfo;
            return View(ViewName, model);
        }

        [HttpPost]
        public IActionResult AddAnimal(BagWebConsoleModel model)
        {
            bool isAnimalAdded = bagService.AddAnimal(animalFactory.CreateAnimal(model.name,model.animalFoodPerDay, (AnimalType) model.animalTypeNumber));
            if (isAnimalAdded)
            {
                model.Info = AnimalWasAddedSuccessfully;
                return View(ViewName, model);
            }
            model.Info = ThereIsNoPlaceForAnimalSuchType;
            return View(ViewName, model);
        }
        [HttpGet]
        public IActionResult AnimalJumpIntoBag(BagWebConsoleModel model)
        {
            bool isAnimalAdded = bagService.AnimalTryJumpIntoBag();
            if (isAnimalAdded)
            {
                model.Info = AnimalJumpedSuccessfully;
                return View(ViewName, model);
            }
            model.Info = ThereIsNoPlaceForJumpedAnimalType;
            return View(ViewName, model);
        }
        [HttpGet]
        public IActionResult SetDay(BagWebConsoleModel model)
        {
            bagService.SetDay();
            model.Info = NowIsDayInBag;
            return View(ViewName, model);
        }
        [HttpGet]
        public IActionResult SetNight(BagWebConsoleModel model)
        {
            bagService.SetNight();
            model.Info = NowIsNightInBag;
            return View(ViewName, model);
        }
        [HttpGet]
        public IActionResult CountAllAnimals(BagWebConsoleModel model)
        {
            model.Info = AmountAnimalsIs+bagService.CountAllAnimals();
            return View(ViewName, model);
        }
        [HttpGet]
        public IActionResult AverageFoodWeightPerAnimal(BagWebConsoleModel model)
        {
            model.Info = AverageFoodWeightPerAnima+bagService.GetAverageFoodWeightPerAnimal();
            return View(ViewName, model);
        }
        [HttpGet]
        public IActionResult TotalFoodWeightPerDay(BagWebConsoleModel model)
        {
            model.Info = TotalFoodWeightPerDayOnAnimal+bagService.GetTotalFoodWeightPerDay();
            return View(ViewName, model);
        }
        [HttpGet]
        public IActionResult CommandVoiceToAllAnimals(BagWebConsoleModel model)
        {
            try
            {
                model.Info = AnimalsSays+bagService.CommandVoiceToAllAnimals();
                return View(ViewName, model);
            }
            catch (CallAllAnimalsAtNightException e)
            {
                model.Info = YouCantCallAllAnimalsAtNight;
                return View(ViewName, model);
            }
        }
        [HttpPost]
        public IActionResult CommandVoiceToConcreteAnimal(BagWebConsoleModel model)
        {
            model.Info = YouCalledAnimalWithName+model.name+AndHear+bagService.CommandVoiceToConcreteAnimal(model.name);
            return View(ViewName, model);
        }
    }
}
