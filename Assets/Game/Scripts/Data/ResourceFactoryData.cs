using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ResourceFactoryData")]
[InlineEditor]
public class ResourceFactoryData : ScriptableObject
{
    public ResourceType GettableResource;
    public ResourceSpawner GetableResourceSpawner;
    public ResourceSpawner GiveableResourceSpawner;
    public float CreateTime;
    public float GetResourceDelay;
    public int MinResourceToActive;
}