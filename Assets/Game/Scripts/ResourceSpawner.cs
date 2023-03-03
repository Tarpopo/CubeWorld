using System;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ResourceSpawner
{
    [SerializeField] private ResourceSpawnerData _spawnerData;
    [SerializeField] private GameObject _resourcePrefab;
    [SerializeField] private Transform _spawnPoint;
    private ManagerPool _managerPool;

    public void SetParameters(ManagerPool managerPool)
    {
        _managerPool = managerPool;
        _managerPool.AddPool(PoolType.Entities);
    }

    public void SpawnResources()
    {
        for (int i = 0; i < _spawnerData.ResourceCount; i++)
        {
            var resource = _managerPool.Spawn<Rigidbody>(PoolType.Entities, _resourcePrefab, _spawnPoint.position);
            resource.velocity = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) *
                                (_spawnerData.ForceDirection.normalized * _spawnerData.SpawnForce);
        }
    }
}