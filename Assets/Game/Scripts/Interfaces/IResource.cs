public interface IResource : IDamageable
{
    public ResourceType ResourceType { get; }
    public bool CanMine { get; }
}