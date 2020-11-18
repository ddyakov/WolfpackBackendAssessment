namespace WolfpackBackendAssessment.Domain.Factories.Wolves
{
    using Exceptions;
    using Models.Wolves;
	using Domain.Common;

	internal class WolfFactory : IWolfFactory
    {
        private string _name = default!;
        private Gender _gender = Gender.AlphaMale;
        private Location _location = default!;

        private bool _nameSet = false;
        private bool _locationSet = false;

        public IWolfFactory WithName(string name)
		{
            _name = name;
            _nameSet = true;

            return this;
		}

        public IWolfFactory WithGender(string gender)
		{
            _gender = !string.IsNullOrEmpty(gender) ? Enumeration.FromName<Gender>(gender) : _gender;
            return this;
		}

        public IWolfFactory WithLocation(string latitude, string longitude)
            => WithLocation(new Location(latitude, longitude));

        public IWolfFactory WithLocation(Location location)
        {
            _location = location;
            _locationSet = true;

            return this;
        }

        public Wolf Build()
        {
            if (!_nameSet || !_locationSet)
                throw new InvalidWolfException("A wolf must have a name and location.");

            return new Wolf(_name, _gender, _location);
        }
    }
}
