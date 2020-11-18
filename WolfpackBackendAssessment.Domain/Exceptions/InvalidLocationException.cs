namespace WolfpackBackendAssessment.Domain.Exceptions
{
	public class InvalidLocationException : BaseDomainException
    {
        public InvalidLocationException()
        {
        }

        public InvalidLocationException(string error) => Error = error;
    }
}
