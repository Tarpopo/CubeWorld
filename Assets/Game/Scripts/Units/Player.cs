using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(TransformRotate))]
[RequireComponent(typeof(AnimationComponent))]
[RequireComponent(typeof(NavMeshMove))]
public class Player : BaseUnit, IResourceContainer
{
    public event Action<ResourceType> OnRemoveResource;
    public Transform ContainPoint => _resourceCollector.CollectPoint;

    [SerializeField] private PlayerData _playerData;
    [SerializeField] private float _angleOffset = 140;
    private PlayerInput _playerInput;
    private TriggerChecker<IResourcePoint> _resourceChecker;
    private ResourcesUISetter _resourcesUISetter;
    private ResourceCollector _resourceCollector;

    public void TryAttackResource()
    {
        // if (_resourceChecker.HaveElements == false) return;
        // foreach (var resource in _resourceChecker.Elements) resource.TakeDamage(1);
        // if (_resourceChecker.Elements.Any(resource => resource.CanMine) == false)
        // {
        //     _animationComponent.PlayAnimation(UnitAnimations.Idle);
        //     _stateMachine.ChangeState<Idle>();
        // }
    }

    public bool TryTakeResource(ResourceType resourceType)
    {
        var resource = _resourcesUISetter.GetResource(resourceType);
        if (resource.HaveResource == false) return false;
        resource.RemoveResourceValue(1);
        OnRemoveResource?.Invoke(resourceType);
        return true;
    }

    protected override void Start()
    {
        // Application.targetFrameRate = 60;
        // base.Start();
        // _resourceChecker = new TriggerChecker<IResourcePoint>();
        // _resourcesUISetter = FindObjectOfType<ResourcesUISetter>();
        // _playerInput = FindObjectOfType<PlayerInput>();
        // _resourceCollector = GetComponentInChildren<ResourceCollector>();
        // _resourceCollector.SetParameters(_playerData.ResourceTakeDelay, _playerData.ResourceCheckRadius);
        // _stateMachine.AddState(new PlayerMove(_stateMachine, _playerInput, Camera.main.transform, _move, _rotateMove,
        //     transform, _playerData.MoveSpeed, _angleOffset));
        // _stateMachine.AddState(new Idle(_stateMachine));
        // _stateMachine.AddState(new PlayerAttack(_stateMachine, _animationComponent, _resourceChecker));
        // _playerInput.OnTouchDown += () =>
        // {
        //     _animationComponent.PlayAnimation(UnitAnimations.Run);
        //     _stateMachine.ChangeState<PlayerMove>();
        // };
        // _playerInput.OnTouchUp += () =>
        // {
        //     if (_resourceChecker.HaveElements && _resourceChecker.Elements.Any(resource => resource.CanMine))
        //     {
        //         _stateMachine.ChangeState<PlayerAttack>();
        //     }
        //     else
        //     {
        //         _animationComponent.PlayAnimation(UnitAnimations.Idle);
        //         _stateMachine.ChangeState<Idle>();
        //     }
        // };
        // _animationComponent.PlayAnimation(UnitAnimations.Idle);
        // _stateMachine.Initialize<Idle>();
    }

    private void OnTriggerEnter(Collider other) => _resourceChecker.OnTriggerEnter(other);

    private void OnTriggerStay(Collider other) => _resourceChecker.OnTriggerStay(other);

    private void OnTriggerExit(Collider other) => _resourceChecker.OnTriggerExit(other);
}