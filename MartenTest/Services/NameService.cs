using Marten;
using MartenTest.Projections;
using static MartenTest.Events.Events;

namespace MartenTest.Services
{
    public class NameService
    {
        private readonly IDocumentSession _session;

        public NameService(IDocumentSession session)
        {
            _session = session;
        }

        public P1 GetNameOfStudents(string id)
        {
            var result = _session.Events.AggregateStream<P1>(new Guid(id));
            return result;
        }



        // Metode der bruges til at oprette bruger   
        public async Task<Guid> CreateUser()
        {
            var result = _session.Events.StartStream(new UserCreation(new Guid()));
            await _session.SaveChangesAsync();
            return result.Id;
        }

        public async Task<Guid> AddPersonalInformation(string name, int age, string id, string email, string phone)
        {
            var result = _session.Events.Append(new Guid(id), new UpdatePersonalInformation(name, age, email, phone));
            await _session.SaveChangesAsync();
            return result.Id;
        }

        public async Task<string> CreateListOfStudents()
        {
            var result = _session.Events.StartStream(new CreateListOfStudents(new Guid()));
            await _session.SaveChangesAsync();
            return "List has been created with ID: " + result.Id;
        }
        public async Task<string> AddToListOfStudents(string listId, string userId)
        {
            var result = _session.Events.Append(new Guid(listId), userId);
            await _session.SaveChangesAsync();
            return $"{userId} has been added to {listId}";
        }
    }
}
