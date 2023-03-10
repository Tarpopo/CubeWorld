using System;
using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ResourceCollector : MonoBehaviour, ICollector<ResourceType>
{
    public event Action<ResourceType> OnCollect;
    public Transform CollectPoint => _collectPoint;
    [SerializeField] private Transform _collectPoint;
    private float _flyDelay = 0.25f;
    private TriggerChecker<ICollectableResource> _resourceTrigger;
    private ResourcesUISetter _resourcesUISetter;
    private ManagerPool _managerPool;
    private Coroutine _coroutine;

    public void SetParameters(float flyDelay, float takeRadius)
    {
        _flyDelay = flyDelay;
        GetComponent<SphereCollider>().radius = takeRadius;
    }

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
            OnCollect?.Invoke(collectable.ResourceType);
        });
    }

    private void OnTriggerEnter(Collider other) => _resourceTrigger.OnTriggerEnter(other);
    private void OnTriggerStay(Collider other) => _resourceTrigger.OnTriggerStay(other);
    private void OnTriggerExit(Collider other) => _resourceTrigger.OnTriggerExit(other);
}