using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ResourcePointData")]
[InlineEditor]
public class ResourcePointData : ScriptableObject
{
    public ResourceType ResourceType;
    public PrefabStateCalculator StateCalculator;
    public ResourceSpawner ResourceSpawner;
    public int HitsToDestroy;
    public float RestoreTick = 2;
}