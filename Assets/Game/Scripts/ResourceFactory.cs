using System.Collections;
using UnityEngine;

public class ResourceFactory : MonoBehaviour
{
    [SerializeField] private ResourceType _gettableResource;
    [SerializeField] private ResourceType _giveableResource;
    [SerializeField] private ResourceSpawner _getableResourceSpawner;
    [SerializeField] private ResourceSpawner _giveableResourceSpawner;
    [SerializeReference] private BaseTweenAnimation _scaleAnimation;
    [SerializeField] private float _createTime;
    [SerializeField] private float _getResourceDelay;
    [SerializeField] private int _minResourceToActive;
    private int _currentResourceCount;
    private TriggerChecker<IResourceContainer> _resourceContainerChecker;
    private Coroutine _generatorCoroutine;
    private Coroutine _getterCoroutine;
    private PlayerInput _playerInput;
    private ManagerPool _managerPool;
    private AnimationComponent _animationComponent;

    private void Start()
    {
        _animationComponent = GetComponent<AnimationComponent>();
        _playerInput = FindObjectOfType<PlayerInput>();
        _resourceContainerChecker = new TriggerChecker<IResourceContainer>();
        _managerPool = FindObjectOfType<ManagerPool>();
        _getableResourceSpawner.SetParameters(_managerPool);
        _giveableResourceSpawner.SetParameters(_managerPool);
        _playerInput.OnTouchUp += TryStartGettingResource;
    }

    private IEnumerator CreateResourceCoroutine()
    {
        _animationComponent.PlayAnimation(SpotsAnimations.Active);
        while (_currentResourceCount >= _minResourceToActive)
        {
            yield return new WaitForSeconds(_createTime);
            _giveableResourceSpawner.SpawnResources();
            _scaleAnimation.PlayAnimation();
            _currentResourceCount -= _minResourceToActive;
        }

        _animationComponent.PlayAnimation(SpotsAnimations.Idle);
        _generatorCoroutine = null;
    }

    private IEnumerator GetResourceCoroutine()
    {
        while (_resourceContainerChecker.HaveElements &&
               _resourceContainerChecker.First.TryTakeResource(_gettableResource))
        {
            _getableResourceSpawner.SpawnResources(transform, _resourceContainerChecker.First.ContainPoint, 0.2f, () =>
            {
                _currentResourceCount++;
                _scaleAnimation.PlayAnimation();
                TryStartResourceGenerator();
            });
            yield return new WaitForSeconds(_getResourceDelay);
        }

        _getterCoroutine = null;
    }

    private void TryStartResourceGenerator()
    {
        if (_currentResourceCount <= _minResourceToActive || _generatorCoroutine != null) return;
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