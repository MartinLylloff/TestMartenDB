using static MartenTest.Events.Events;

namespace MartenTest.Projections
{
    public class Projector
    {
        public void Apply(P1 snapshot, UpdatePersonalInformation e)
        {
            snapshot.AllUsers.Add(e.Name);
        }
    }
}
