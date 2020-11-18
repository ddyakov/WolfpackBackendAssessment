namespace WolfpackBackendAssessment.Domain.Models.Packs
{
	using System.Linq;
	using System.Collections.Generic;

	using Common;
	using Wolves;
	using Exceptions;

	using static ModelConstants;

	public class Pack : Entity<int>, IAggregateRoot
	{
		private readonly HashSet<Wolf> _wolves;

		internal Pack(string name)
		{
			ValidateName(name);

			Name = name;
			_wolves = new HashSet<Wolf>();
		}

		public string Name { get; private set; }

		public IReadOnlyCollection<Wolf> Wolves => _wolves.ToList().AsReadOnly();

		public Pack UpdateName(string name)
		{
			ValidateName(name);
			Name = name;

			return this;
		}

		public void AddWolf(Wolf wolf) => _wolves.Add(wolf);

		public void RemoveWolf(Wolf wolf) => _wolves.Remove(wolf);

		private void ValidateName(string name)
			=> Guard
				.ForStringLength<InvalidPackException>(
					name,
					MinNameLength,
					MaxNameLength,
					nameof(Name));
	}
}
