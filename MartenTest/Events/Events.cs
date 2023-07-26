namespace MartenTest.Events
{
    public class Events
    {
        public record UserCreation(Guid UserId);
        public record UpdatePersonalInformation(string Name, int Age, string Email, string Phone);
        public record CreateListOfStudents(Guid ListId);
    }
}
