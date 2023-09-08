using Module1;

namespace Database.Module1;

public sealed class Module1Registry : ModuleRegistryBase
{
	protected override string SchemaName => "module1";

	public Module1Registry()
	{
		RegisterAggregate<Module1Aggregate>();
	}
}
