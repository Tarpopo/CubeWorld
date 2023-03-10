public interface IResourceUI : IResource
{
    bool HaveResource { get; }
    void AddResourceValue(int value);
    void RemoveResourceValue(int value);
    void Enable();
    void Disable();
}