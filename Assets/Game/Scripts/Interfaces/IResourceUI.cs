public interface IResourceUI : IResource
{
    void AddResourceValue(int value);
    void RemoveResourceValue(int value);
    bool HaveResource { get; }
}