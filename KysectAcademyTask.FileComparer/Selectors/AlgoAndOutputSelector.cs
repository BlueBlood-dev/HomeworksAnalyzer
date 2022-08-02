using System;

namespace KysectAcademyTask.FileComparer
{
    public class AlgoAndOutputSelector : ISelector
    {
        public IComparator ChooseTheComparingAlgo(string comparingAlgo)
        {
            switch (comparingAlgo.ToLower())
            {
                case "multitude algo":
                    return new MultitudeComparator();
                default:
                    throw new ArgumentException("there is no such algo");
            }
        }

        public IWriter ChooseTheOutputType(string typeOfOutput)
        {
            switch (typeOfOutput.ToLower())
            {
                case "json":
                    return new JsonWriter();
                case "console":
                    return new ConsoleWriter();
                case "txt":
                    return new FileWriter();
            }

            throw new InvalidOperationException();
        }
    }
}