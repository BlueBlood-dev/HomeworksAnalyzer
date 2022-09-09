namespace KysectAcademyTask.DatabaseLayer;

public class UniqueValueController
{
    public bool CheckIfResultExists(int firstSubmissionId, int secondSubmissionId, DataBaseContext db)
    {
        return db.Results.ToList().Any(s =>
            s.FirstSubmitId == firstSubmissionId && s.SecondSubmitId == secondSubmissionId);
    }
}