using System.Linq;
using UnityEngine;

public class ResourcesUISetter : MonoBehaviour
{
    private IResourceUI[] _resources;

    private void Start() => _resources = GetComponentsInChildren<IResourceUI>();

    public void AddResource(IResource resource) =>
        _resources.First(item => item.ResourceType.Equals(resource.ResourceType)).AddResourceValue(1);

    public IResourceUI GetResource(ResourceType resourceType) =>
        _resources.First(item => item.ResourceType.Equals(resourceType));
}