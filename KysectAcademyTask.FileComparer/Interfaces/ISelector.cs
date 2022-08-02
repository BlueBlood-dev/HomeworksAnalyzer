namespace KysectAcademyTask.FileComparer.Interfaces
{
    public interface ISelector
    {
        IComparator ChooseTheComparingAlgo(string comparingAlgo);
        IWriter ChooseTheOutputType(string typeOfOutput);
        ISubmitsComparerLogic ChooseTheLogic(string userAnswer);

    }
}