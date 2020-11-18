namespace WolfpackBackendAssessment.Domain.Exceptions
{
	public class InvalidWolfException : BaseDomainException
    {
        public InvalidWolfException()
        {
        }

        public InvalidWolfException(string error) => Error = error;
    }
}
