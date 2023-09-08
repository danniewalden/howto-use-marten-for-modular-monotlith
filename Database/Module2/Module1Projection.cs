using Marten;
using Marten.Events;
using Marten.Events.Projections;

namespace Database.Module2;

public class Module2Projection : IProjection
{
	public void Apply(IDocumentOperations operations, IReadOnlyList<StreamAction> streams)
	{
		throw new NotSupportedException("Subscription should be only run asynchronously");
	}

	public async Task ApplyAsync(IDocumentOperations operations, IReadOnlyList<StreamAction> streams, CancellationToken cancellation)
	{
		await Task.CompletedTask;
	}
}
