using KysectAcademyTask.DatabaseLayer.Entities;

namespace KysectAcademyTask.DatabaseLayer;

public class DataBaseSaver
{
    public void Save(ICollection<ResultOfCompare> compares, DataBaseContext db)
    {
            
        foreach (ResultOfCompare resultOfCompare in compares)
        {
            db.Add(resultOfCompare);
        }

        db.SaveChanges();
    }
}