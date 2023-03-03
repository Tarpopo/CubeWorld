using System.Linq;
using FSM;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rollDistance;
    [SerializeField] private float _angleOffset;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private PlayerInput _playerInput;
    private IMove _move;
    private IRotateMove _rotateMove;
    private float _distToCam;

    private Transform _transform;
    private Camera _camera;
    private Rigidbody _rigidBody;
    private Vector3 _beganPos;
    private Vector3 _moveDirection;
    private Vector3 _rayPos;
    private StateMachine _stateMachine;
    private AnimationComponent _animationComponent;
    private TriggerChecker<IResource> _resourceChecker;

    public void TryAttackResource()
    {
        if (_resourceChecker.HaveElements == false) return;
        foreach (var resource in _resourceChecker.Elements)
        {
            resource.TakeDamage(1);
        }

        if (_resourceChecker.Elements.Any(resource => resource.CanMine) == false)
        {
            _animationComponent.PlayAnimation(UnitAnimations.Idle);
            _stateMachine.ChangeState<Idle>();
        }
    }

    private void Start()
    {
        _resourceChecker = new TriggerChecker<IResource>();
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
                print("attack");
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

    private void OnTriggerEnter(Collider other)
    {
        _resourceChecker.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        _resourceChecker.OnTriggerExit(other);
    }
}