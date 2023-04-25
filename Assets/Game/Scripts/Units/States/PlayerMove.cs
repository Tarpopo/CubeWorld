using FSM;
using UnityEngine;

public class PlayerMove : State
{
    private IMove _move;
    private IRotateMove _rotateMove;
    private PlayerInput _playerInput;
    private Transform _transform;
    private Transform _camera;
    private float _moveSpeed;
    private float _angleOffset;

    public PlayerMove(StateMachine stateMachine, PlayerInput playerInput, Transform camera, IMove move,
        IRotateMove rotateMove, Transform transform, float moveSpeed, float angleOffset) : base(stateMachine)
    {
        _move = move;
        _rotateMove = rotateMove;
        _playerInput = playerInput;
        _transform = transform;
        _camera = camera;
        _moveSpeed = moveSpeed;
        _angleOffset = angleOffset;
    }

    public override void PhysicsUpdate()
    {
        // _move.Move(_transform.position + _transform.forward * _moveSpeed, _moveSpeed);
        // _rotateMove.Rotate(Quaternion.AngleAxis(-_playerInput.Angle + _angleOffset, Vector3.up));
        _move.Move(_transform.position + _transform.forward * _moveSpeed, _moveSpeed);
        var joystickDirection = Quaternion.AngleAxis(_camera.rotation.eulerAngles.y, Vector3.up) *
                                new Vector3(_playerInput.MoveDirection.x, 0, _playerInput.MoveDirection.y).normalized;
        _transform.forward = joystickDirection.normalized;
    }

    public override void LogicUpdate()
    {
        
    }
}