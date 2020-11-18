namespace WolfpackBackendAssessment.Domain.Factories.Packs
{
    using Domain.Exceptions;
    using Domain.Models.Packs;

    internal class PackFactory : IPackFactory
	{
        private string _name = default!;

        private bool _nameSet = false;

        public IPackFactory WithName(string name)
        {
            _name = name;
            _nameSet = true;

            return this;
        }

        public Pack Build()
        {
            if (!_nameSet)
                throw new InvalidPackException("A pack must have a name.");

            return new Pack(_name);
        }
    }
}
