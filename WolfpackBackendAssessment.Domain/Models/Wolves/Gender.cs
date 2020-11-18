namespace WolfpackBackendAssessment.Domain.Models.Wolves
{
    using Common;

    public class Gender : Enumeration
    {
        public static readonly Gender AlphaMale = new Gender(1, nameof(AlphaMale));
        public static readonly Gender AlphaFemale = new Gender(2, nameof(AlphaFemale));
        public static readonly Gender OmegaMale = new Gender(3, nameof(OmegaMale));
        public static readonly Gender OmegaFemale = new Gender(4, nameof(OmegaFemale));

        private Gender(int value)
            : this(value, FromValue<Gender>(value).Name)
        {
        }

        private Gender(int value, string name)
            : base(value, name)
        {
        }
    }
}
