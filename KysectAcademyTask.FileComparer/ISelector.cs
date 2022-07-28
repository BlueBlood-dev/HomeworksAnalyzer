namespace KysectAcademyTask.FileComparer
{
    public interface ISelector
    {
        IComparator ChooseTheComparingAlgo(string comparingAlgo);
        IWriter ChooseTheOutputType(string typeOfOutput);
    }
}