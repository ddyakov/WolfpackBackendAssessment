namespace WolfpackBackendAssessment.Application.Features.Common
{
	public abstract class CreateOutputModel
	{
		public CreateOutputModel(int id)
			=> Id = id;

		public int Id { get; }
	}
}
