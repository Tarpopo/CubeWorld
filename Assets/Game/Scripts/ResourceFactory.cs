using System.Collections;
using UnityEngine;

public class ResourceFactory : MonoBehaviour
{
    [SerializeField] private ResourceFactoryData _factoryData;
    [SerializeField] private Transform _spawnPoint;
    [SerializeReference] private BaseTweenAnimation _scaleAnimation;
    private int _currentResourceCount;
    private TriggerChecker<IResourceContainer> _resourceContainerChecker;
    private Coroutine _generatorCoroutine;
    private Coroutine _getterCoroutine;
    private PlayerInput _playerInput;
    private ManagerPool _managerPool;
    private AnimationComponent _animationComponent;

    private void Start()
    {
        _factoryData = Instantiate(_factoryData);
        _animationComponent = GetComponent<AnimationComponent>();
        _playerInput = FindObjectOfType<PlayerInput>();
        _resourceContainerChecker = new TriggerChecker<IResourceContainer>();
        _managerPool = FindObjectOfType<ManagerPool>();
        _factoryData.GetableResourceSpawner.SetParameters(_managerPool, _spawnPoint);
        _factoryData.GiveableResourceSpawner.SetParameters(_managerPool, _spawnPoint);
        _playerInput.OnTouchUp += TryStartGettingResource;
    }

    private IEnumerator CreateResourceCoroutine()
    {
        _animationComponent.PlayAnimation(SpotsAnimations.Active);
        while (_currentResourceCount >= _factoryData.MinResourceToActive)
        {
            yield return new WaitForSeconds(_factoryData.CreateTime);
            _factoryData.GiveableResourceSpawner.SpawnResources();
            _scaleAnimation.PlayAnimation();
            _currentResourceCount -= _factoryData.MinResourceToActive;
        }

        _animationComponent.PlayAnimation(SpotsAnimations.Idle);
        _generatorCoroutine = null;
    }

    private IEnumerator GetResourceCoroutine()
    {
        while (_resourceContainerChecker.HaveElements &&
               _resourceContainerChecker.First.TryTakeResource(_factoryData.GettableResource))
        {
            _factoryData.GetableResourceSpawner.SpawnResources(transform, _resourceContainerChecker.First.ContainPoint,
                0.2f, () =>
                {
                    _currentResourceCount++;
                    _scaleAnimation.PlayAnimation();
                    TryStartResourceGenerator();
                });
            yield return new WaitForSeconds(_factoryData.GetResourceDelay);
        }

        _getterCoroutine = null;
    }

    private void TryStartResourceGenerator()
    {
        if (_currentResourceCount < _factoryData.MinResourceToActive || _generatorCoroutine != null) return;
        _generatorCoroutine = StartCoroutine(CreateResourceCoroutine());
    }

    private void TryStartGettingResource()
    {
        if (_resourceContainerChecker.HaveElements == false || _getterCoroutine != null) return;
        _getterCoroutine = StartCoroutine(GetResourceCoroutine());
    }

    private void OnTriggerStay(Collider other) => _resourceContainerChecker.OnTriggerStay(other);

    private void OnTriggerEnter(Collider other) => _resourceContainerChecker.OnTriggerEnter(other);

    private void OnTriggerExit(Collider other) => _resourceContainerChecker.OnTriggerExit(other);
}