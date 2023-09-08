namespace Shared;

public abstract class AggregateRoot
{
	protected AggregateRoot(string id)
	{
		Id = id;
	}

	public string Id { get;  }
}
