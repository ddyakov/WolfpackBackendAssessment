namespace WolfpackBackendAssessment.Domain.Models.Wolves
{
	using Common;
	using Exceptions;

	public class Location
	{
		internal Location(string latitude, string longitude)
		{
			Validate(latitude, longitude);

			Latitude = latitude;
			Longitude = longitude;
		}

		public string Latitude { get; private set; }

		public string Longitude { get; private set; }

		public Location UpdateLatitude(string latitude)
		{
			ValidateCoordinate(latitude, nameof(Latitude));
			Latitude = latitude;

			return this;
		}

		public Location UpdateLongitude(string longitude)
		{
			ValidateCoordinate(longitude, nameof(Longitude));
			Longitude = longitude;

			return this;
		}

		private void Validate(string latitude, string longitude)
		{
			ValidateCoordinate(latitude, nameof(Latitude));
			ValidateCoordinate(longitude, nameof(Longitude));
		}

		private void ValidateCoordinate(string coordinate, string value)
			=> Guard.AgainstEmptyString<InvalidLocationException>(coordinate, value);
	}
}