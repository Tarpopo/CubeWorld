using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ResourceSpawnerData")]
[InlineEditor]
public class ResourceSpawnerData : ScriptableObject
{
    public Vector3 ForceDirection => _forceDirection;
    public float SpawnForce => _spawnForce;
    public int ResourceCount => _resourceCount;

    [SerializeField] private Vector3 _forceDirection = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private float _spawnForce;
    [SerializeField] private int _resourceCount;
}