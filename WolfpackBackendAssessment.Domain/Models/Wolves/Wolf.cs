namespace WolfpackBackendAssessment.Domain.Models.Wolves
{
	using Common;
	using Exceptions;

	using static ModelConstants;

	public class Wolf : 
		Entity<int>, 
		IAggregateRoot
	{
		internal Wolf(string name, Gender gender, Location location)
		{
			ValidateName(name);

			Name = name;
			Gender = gender;
			Location = location;
		}

		private Wolf(string name)
		{
			Name = name;
			Gender = default!;
			Location = default!;
		}

		public string Name { get; private set; }

		public Gender Gender { get; private set; }

		public Location Location { get; private set; }

		public Wolf UpdateName(string name)
		{
			ValidateName(name);
			Name = name;

			return this;
		}

		public Wolf UpdateGender(Gender gender)
		{
			if (Gender != gender)
				Gender = gender;

			return this;
		}

		public Wolf UpdateLocation(string latitude, string longitude)
		{
			if (Location.Latitude != latitude || Location.Longitude != longitude)
				Location = new Location(latitude, longitude);

			return this;
		}

		private void ValidateName(string name)
			=> Guard
				.ForStringLength<InvalidWolfException>(
					name,
					MinNameLength,
					MaxNameLength,
					nameof(Name));
	}
}
