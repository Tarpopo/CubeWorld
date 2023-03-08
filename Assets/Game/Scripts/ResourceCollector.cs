using DefaultNamespace;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    public Transform CollectPoint => _collectPoint;
    [SerializeField] private Transform _collectPoint;
    [SerializeField] private float _flyDelay;
    private TriggerChecker<ICollectableResource> _resourceTrigger;
    private ResourcesUISetter _resourcesUISetter;
    private ManagerPool _managerPool;
    private Coroutine _coroutine;

    private void Start()
    {
        _managerPool = FindObjectOfType<ManagerPool>();
        _resourcesUISetter = FindObjectOfType<ResourcesUISetter>();
        _resourceTrigger = new TriggerChecker<ICollectableResource>();
        _resourceTrigger.OnObjectEnter += CollectItem;
    }

    private void CollectItem(ICollectableResource collectable)
    {
        if (collectable.Collecting) return;
        collectable.Collect(_collectPoint, _flyDelay, () =>
        {
            _managerPool.Despawn(PoolType.Entities, collectable.Resource);
            _resourceTrigger.TryRemoveItem(collectable.Resource);
            _resourcesUISetter.AddResource(collectable);
        });
    }

    private void OnTriggerEnter(Collider other) => _resourceTrigger.OnTriggerEnter(other);
    private void OnTriggerStay(Collider other) => _resourceTrigger.OnTriggerStay(other);
    private void OnTriggerExit(Collider other) => _resourceTrigger.OnTriggerExit(other);
}