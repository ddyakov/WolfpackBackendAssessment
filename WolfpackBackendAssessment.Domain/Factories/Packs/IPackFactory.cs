namespace WolfpackBackendAssessment.Domain.Factories.Packs
{
	using Domain.Models.Packs;

	public interface IPackFactory : IFactory<Pack>
	{
		IPackFactory WithName(string name);
	}
}
