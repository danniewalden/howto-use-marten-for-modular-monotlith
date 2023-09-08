using Marten;
using Shared;

namespace Database;

public abstract class ModuleRegistryBase : MartenRegistry
{
	protected abstract string SchemaName { get; }

	protected DocumentMappingExpression<T> RegisterAggregate<T>() where T : AggregateRoot
	{
		return For<T>()
			.Identity(x => x.Id)
			.DatabaseSchemaName(SchemaName);
	}
}
