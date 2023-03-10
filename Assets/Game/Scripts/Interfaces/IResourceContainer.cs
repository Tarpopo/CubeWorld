using System;
using UnityEngine;

public interface IResourceContainer
{
    event Action<ResourceType> OnRemoveResource;
    Transform ContainPoint { get; }
    bool TryTakeResource(ResourceType resourceType);
}