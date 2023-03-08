using UnityEngine;

public interface IResourceContainer
{
    Transform ContainPoint { get; }
    bool TryTakeResource(ResourceType resourceType);
}