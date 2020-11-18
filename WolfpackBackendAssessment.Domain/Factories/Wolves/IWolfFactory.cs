namespace WolfpackBackendAssessment.Domain.Factories.Wolves
{
	using Domain.Models.Wolves;

	public interface IWolfFactory : IFactory<Wolf>
	{
        IWolfFactory WithName(string name);

        IWolfFactory WithGender(string gender);

        IWolfFactory WithLocation(string latitude, string longitude);

        IWolfFactory WithLocation(Location location);
    }
}
