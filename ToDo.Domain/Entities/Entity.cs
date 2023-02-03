namespace ToDo.Domain.Entities;

/// <summary>
/// Base entity class
/// </summary>
public abstract class Entity : IEquatable<Entity>
{
	public Entity() => Id = Guid.NewGuid();

	/// <summary>
	/// Auto-generated unique identifier for each entity
	/// </summary>
	/// <value></value>
	public Guid Id { get; private set; }

	public bool Equals(Entity? other) => other != null && other.Id == Id;
}