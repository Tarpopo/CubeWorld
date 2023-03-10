﻿using System;
using System.Linq;
using FSM;
using UnityEngine;

public class Player : MonoBehaviour, IResourceContainer
{
    public event Action<ResourceType> OnRemoveResource;
    public Transform ContainPoint => _resourceCollector.CollectPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _angleOffset;
    [SerializeField] private PlayerInput _playerInput;
    private IMove _move;
    private IRotateMove _rotateMove;
    private StateMachine _stateMachine;
    private AnimationComponent _animationComponent;
    private TriggerChecker<IResourcePoint> _resourceChecker;
    private ResourcesUISetter _resourcesUISetter;
    private ResourceCollector _resourceCollector;

    public void TryAttackResource()
    {
        if (_resourceChecker.HaveElements == false) return;
        foreach (var resource in _resourceChecker.Elements) resource.TakeDamage(1);
        if (_resourceChecker.Elements.Any(resource => resource.CanMine) == false)
        {
            _animationComponent.PlayAnimation(UnitAnimations.Idle);
            _stateMachine.ChangeState<Idle>();
        }
    }

    public bool TryTakeResource(ResourceType resourceType)
    {
        var resource = _resourcesUISetter.GetResource(resourceType);
        if (resource.HaveResource == false) return false;
        resource.RemoveResourceValue(1);
        OnRemoveResource?.Invoke(resourceType);
        return true;
    }

    private void Start()
    {
        _resourcesUISetter = FindObjectOfType<ResourcesUISetter>();
        _resourceCollector = GetComponentInChildren<ResourceCollector>();
        _resourceChecker = new TriggerChecker<IResourcePoint>();
        _animationComponent = GetComponent<AnimationComponent>();
        _move = GetComponent<IMove>();
        _rotateMove = GetComponent<IRotateMove>();
        _stateMachine = new StateMachine();
        _stateMachine.AddState(new PlayerMove(_stateMachine, _playerInput, _move, _rotateMove, transform, _speed,
            _angleOffset));
        _stateMachine.AddState(new Idle(_stateMachine));
        _stateMachine.AddState(new PlayerAttack(_stateMachine, _animationComponent, _resourceChecker));
        _playerInput.OnTouchDown += () =>
        {
            _animationComponent.PlayAnimation(UnitAnimations.Run);
            _stateMachine.ChangeState<PlayerMove>();
        };
        _playerInput.OnTouchUp += () =>
        {
            if (_resourceChecker.HaveElements && _resourceChecker.Elements.Any(resource => resource.CanMine))
            {
                _stateMachine.ChangeState<PlayerAttack>();
            }
            else
            {
                _animationComponent.PlayAnimation(UnitAnimations.Idle);
                _stateMachine.ChangeState<Idle>();
            }
        };
        _animationComponent.PlayAnimation(UnitAnimations.Idle);
        _stateMachine.Initialize<Idle>();
    }

    private void Update() => _stateMachine.CurrentState.LogicUpdate();

    private void FixedUpdate() => _stateMachine.CurrentState.PhysicsUpdate();

    private void OnTriggerEnter(Collider other) => _resourceChecker.OnTriggerEnter(other);

    private void OnTriggerStay(Collider other) => _resourceChecker.OnTriggerStay(other);

    private void OnTriggerExit(Collider other) => _resourceChecker.OnTriggerExit(other);
}