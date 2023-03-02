using FSM;
using UnityEngine;

public class PlayerMove : State
{
    private IMove _move;
    private IRotateMove _rotateMove;
    private PlayerInput _playerInput;
    private Transform _transform;
    private float _moveSpeed;
    private float _angleOffset;

    public PlayerMove(StateMachine stateMachine, PlayerInput playerInput, IMove move, IRotateMove rotateMove,
        Transform transform, float moveSpeed,float angleOffset) :
        base(stateMachine)
    {
        _move = move;
        _rotateMove = rotateMove;
        _playerInput = playerInput;
        _transform = transform;
        _moveSpeed = moveSpeed;
        _angleOffset = angleOffset;
    }

    public override void PhysicsUpdate()
    {
        _move.Move(_transform.position + _transform.forward * _moveSpeed, _moveSpeed);
        _rotateMove.Rotate(Quaternion.AngleAxis(-_playerInput.Angle + _angleOffset, Vector3.up));
    }
}