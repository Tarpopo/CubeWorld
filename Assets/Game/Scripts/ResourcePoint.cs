using UnityEngine;
using UnityEngine.AI;

public class ResourcePoint : MonoBehaviour, IResourcePoint
{
    public bool CanMine => _health.CurrentHealth > 0;
    public ResourceType ResourceType => _resourceType;
    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private PrefabStateCalculator _stateCalculator;
    [SerializeField] private ResourceSpawner _resourceSpawner;
    [SerializeField] private int _hitsToDestroy;
    private Health _health;
    private ValueRestorer _resourceRestorer;
    private NavMeshObstacle _obstacle;

    public void TakeDamage(int damage)
    {
        _health.ReduceHealth(damage);
        _resourceRestorer.StartValueRestoring(this);
    }

    private void DisableComponents() => _obstacle.enabled = false;
    private void EnableComponents() => _obstacle.enabled = true;

    private void Awake()
    {
        _obstacle = GetComponent<NavMeshObstacle>();
        _resourceSpawner.SetParameters(FindObjectOfType<ManagerPool>());
        _stateCalculator.SetParameters(_hitsToDestroy);
        _health = new Health(_hitsToDestroy);
        _resourceRestorer = new ValueRestorer(2, () => _health.MaxHealth == false, _health.AddHealth);
    }

    private void OnEnable()
    {
        _health.OnReduceHealthInt += _stateCalculator.TrySetState;
        _health.OnReduceHealth += _resourceSpawner.SpawnResources;
        _health.OnHealthAddedInt += _stateCalculator.TrySetState;
        _health.OnHealthAdded += EnableComponents;
        _health.OnHealthEnd += DisableComponents;
    }

    private void OnDisable()
    {
        _health.OnReduceHealthInt -= _stateCalculator.TrySetState;
        _health.OnReduceHealth -= _resourceSpawner.SpawnResources;
        _health.OnHealthAddedInt -= _stateCalculator.TrySetState;
        _health.OnHealthAdded -= EnableComponents;
        _health.OnHealthEnd -= DisableComponents;
    }
}