namespace KysectAcademyTask.DatabaseLayer.Entities;

public class ResultOfCompare
{
    public int Id { get; set; }
    public int FirstSubmitId { get; set; }
    public int SecondSubmitId { get; set; }
    public double Result { get; set; }

    public ResultOfCompare( int firstSubmitId, int secondSubmitId, double result)
    {
        FirstSubmitId = firstSubmitId;
        SecondSubmitId = secondSubmitId;
        Result = result;
    }
}