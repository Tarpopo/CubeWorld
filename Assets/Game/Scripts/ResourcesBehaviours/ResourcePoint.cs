using System;
using UnityEngine;
using UnityEngine.AI;

public class ResourcePoint : MonoBehaviour, IResourcePoint
{
    public event Action OnTakeDamage;
    public bool CanMine => _health.CurrentHealth > 0;
    public ResourceType ResourceType => _resourcePointData.ResourceType;
    
    [SerializeField] private ResourcePointData _resourcePointData;
    [SerializeField] private GameObject[] _prefabsStates;
    [SerializeField] private Transform _spawnPoint;
    [SerializeReference] private BaseTweenAnimation _takeDamageAnimation;
    private Health _health;
    private ValueRestorer _resourceRestorer;
    private NavMeshObstacle _obstacle;

    public void TakeDamage(int damage)
    {
        _health.ReduceHealth(damage);
        _resourceRestorer.StartValueRestoring(this);
        _takeDamageAnimation.PlayAnimation();
        OnTakeDamage?.Invoke();
    }

    private void DisableComponents() => _obstacle.enabled = false;
    private void EnableComponents() => _obstacle.enabled = true;

    private void Awake()
    {
        _obstacle = GetComponent<NavMeshObstacle>();
        _resourcePointData = Instantiate(_resourcePointData);
        _resourcePointData.ResourceSpawner.SetParameters(FindObjectOfType<ManagerPool>(), _spawnPoint);
        _resourcePointData.StateCalculator.SetParameters(_resourcePointData.HitsToDestroy, _prefabsStates);
        _health = new Health(_resourcePointData.HitsToDestroy);
        _resourceRestorer = new ValueRestorer(_resourcePointData.RestoreTick, () => _health.MaxHealth == false,
            _health.AddHealth);
    }

    private void OnEnable()
    {
        _health.OnReduceHealthInt += _resourcePointData.StateCalculator.TrySetState;
        _health.OnHealthAddedInt += _resourcePointData.StateCalculator.TrySetState;
        _health.OnReduceHealth += _resourcePointData.ResourceSpawner.SpawnResources;
        _health.OnHealthAdded += EnableComponents;
        _health.OnHealthEnd += DisableComponents;
    }

    private void OnDisable()
    {
        _health.OnReduceHealthInt -= _resourcePointData.StateCalculator.TrySetState;
        _health.OnHealthAddedInt -= _resourcePointData.StateCalculator.TrySetState;
        _health.OnReduceHealth -= _resourcePointData.ResourceSpawner.SpawnResources;
        _health.OnHealthAdded -= EnableComponents;
        _health.OnHealthEnd -= DisableComponents;
    }
}