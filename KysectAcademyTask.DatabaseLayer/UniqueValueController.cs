using System;
using System.Linq;
using KysectAcademyTask.DatabaseLayer.Entities;

namespace KysectAcademyTask.DatabaseLayer
{
    public class UniqueValueController
    {
        public bool CheckIfResultExists(int firstSubmissionId, int secondSubmissionId)
        {
            return new DataBaseData().ResultsOfCompares.Any(s =>
                s.FirstSubmitId == firstSubmissionId && s.SecondSubmitId == secondSubmissionId);
        }
        
    }
}