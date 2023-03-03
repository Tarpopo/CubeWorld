using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

public class Resource : MonoBehaviour, IResource
{
    public ResourceType ResourceType => _resourceType;
    public bool CanMine => _health.CurrentHealth > 0;
    [SerializeField] private PrefabStateCalculator _stateCalculator;
    [SerializeField] private GameObject _resourcePrefab;
    [SerializeField] private Transform _resourceSpawnPoint;
    [SerializeField] private int _hitsToDestroy;
    [SerializeField] private int _resourceCount;
    [SerializeField] private float _spawnForce;
    [SerializeField] private Vector3 _forceDirection = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private ResourceType _resourceType;
    private ManagerPool _managerPool;
    private Health _health;
    private NavMeshObstacle _obstacle;

    // private BoxCollider _boxCollider;

    public void TakeDamage(int damage)
    {
        _health.ReduceHealth(damage);
        SpawnResources();
    }

    private void DisableComponents()
    {
        _obstacle.enabled = false;
    }

    private void Start()
    {
        _obstacle = GetComponent<NavMeshObstacle>();
        _managerPool = FindObjectOfType<ManagerPool>();
        _managerPool.AddPool(PoolType.Entities);
        _health = new Health(_hitsToDestroy);
        _health.OnReduceHealth += _stateCalculator.TrySetState;
        _health.OnHealthAdded += _stateCalculator.TrySetState;
        _health.OnHealthEnd += DisableComponents;
        _stateCalculator.SetParameters(_hitsToDestroy);
    }

    private void SpawnResources()
    {
        for (int i = 0; i < _resourceCount; i++)
        {
            var resource =
                _managerPool.Spawn<Rigidbody>(PoolType.Entities, _resourcePrefab, _resourceSpawnPoint.position);
            resource.velocity =
                Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) * (_forceDirection.normalized * _spawnForce);
        }
    }
}