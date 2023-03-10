using UnityEngine;

[CreateAssetMenu(menuName = "Data/ResourcePointData")]
public class ResourcePointData : ScriptableObject
{
    public PrefabStateCalculator StateCalculator;
    public ResourceSpawner ResourceSpawner;
    public int HitsToDestroy;
}