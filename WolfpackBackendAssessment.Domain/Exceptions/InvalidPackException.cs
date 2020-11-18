namespace WolfpackBackendAssessment.Domain.Exceptions
{
	public class InvalidPackException : BaseDomainException
    {
        public InvalidPackException()
        {
        }

        public InvalidPackException(string error) => Error = error;
    }
}
