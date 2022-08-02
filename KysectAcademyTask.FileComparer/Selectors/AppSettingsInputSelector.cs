﻿using System;
using KysectAcademyTask.FileComparer.Comparators;
using KysectAcademyTask.FileComparer.Interfaces;

namespace KysectAcademyTask.FileComparer.Selectors
{
    public class AppSettingsInputSelector : ISelector
    {
        public IComparator ChooseTheComparingAlgo(string comparingAlgo)
        {
            return comparingAlgo.ToLower() switch
            {
                "multitude algo" => new MultitudeComparator(),
                _ => throw new ArgumentException("there is no such algo")
            };
        }

        public IWriter ChooseTheOutputType(string typeOfOutput)
        {
            return typeOfOutput.ToLower() switch
            {
                "json" => new JsonWriter(),
                "console" => new ConsoleWriter(),
                "txt" => new FileWriter(),
                _ => throw new InvalidOperationException()
            };
        }

        public ISubmitsComparerLogic ChooseTheLogic(string userAnswer)
        {
            return userAnswer.ToLower() switch
            {
                "no" => new ComparingWithoutDatabase(),
                "yes" => new ComparingWithDatabase(),
                _ => throw new ArgumentException("invalid user choice")
            };
        }
    }
}