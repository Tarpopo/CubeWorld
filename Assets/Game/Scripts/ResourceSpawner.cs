using System;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ResourceSpawner
{
    [SerializeField] private ResourceSpawnerData _spawnerData;
    [SerializeField] private GameObject _resourcePrefab;
    private Transform _spawnPoint;
    private ManagerPool _managerPool;

    public void SetParameters(ManagerPool managerPool, Transform spawnPoint)
    {
        _managerPool = managerPool;
        _managerPool.AddPool(PoolType.Entities);
        _spawnPoint = spawnPoint;
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

    public void SpawnResources(Transform collectPoint, Transform spawnPoint, float collectDelay, Action onCollect)
    {
        for (int i = 0; i < _spawnerData.ResourceCount; i++)
        {
            var resource =
                _managerPool.Spawn<ICollectableResource>(PoolType.Entities, _resourcePrefab, spawnPoint.position);
            onCollect += () => _managerPool.Despawn(PoolType.Entities, resource.Resource);
            resource.Collect(collectPoint, collectDelay, onCollect);
            resource.Resource.GetComponent<Rigidbody>().velocity =
                Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) *
                (_spawnerData.ForceDirection.normalized * _spawnerData.SpawnForce);
        }
    }
}