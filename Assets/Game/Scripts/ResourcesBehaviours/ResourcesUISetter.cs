using System.Linq;
using UnityEngine;

public class ResourcesUISetter : MonoBehaviour
{
    private IResourceUI[] _resources;

    private void Start() => _resources = FindObjectsOfType<ResourceUI>(true);

    public void AddResource(IResource resource)
    {
        var iResource = GetResource(resource.ResourceType);
        iResource.Enable();
        iResource.AddResourceValue(1);
    }

    public IResourceUI GetResource(ResourceType resourceType) =>
        _resources.First(item => item.ResourceType.Equals(resourceType));
}