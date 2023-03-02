using UnityEngine;

public class Resource : MonoBehaviour, IResource
{
    public ResourceType ResourceType => _resourceType;
    [SerializeField] private ResourceType _resourceType;

    public void TakeDamage(int damage)
    {
    }
}