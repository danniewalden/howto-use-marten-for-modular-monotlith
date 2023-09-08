using Module2;

namespace Database.Module2;

public sealed class Module2Registry : ModuleRegistryBase
{
	protected override string SchemaName => "module2";

	public Module2Registry()
	{
		RegisterAggregate<Module2Aggregate>();
	}
}
