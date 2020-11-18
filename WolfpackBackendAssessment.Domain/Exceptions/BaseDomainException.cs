namespace WolfpackBackendAssessment.Domain.Exceptions
{
    using System;

    public abstract class BaseDomainException : Exception
    {
        private string? error;

        public string Error
        {
            get => error ?? base.Message;
            set => error = value;
        }
    }
}
