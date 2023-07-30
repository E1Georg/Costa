namespace Costa.Application.Common.Exceptions
{
    public class EntityAlreadyExistException : Exception
    {
        public EntityAlreadyExistException(string name, object key) : base($"Entity \"{name}\" ({key}) already exist in database.") { }
    }
}