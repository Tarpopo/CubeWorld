using FSM;
using UnityEngine;

public class EnemyMove : State
{
    private PointGetter _pointGetter;
    private NavMeshMove _navMeshMove;
    private Transform _point;
    private float _moveSpeed;
    private AnimationComponent _animationComponent;

    public EnemyMove(StateMachine stateMachine, PointGetter pointGetter, AnimationComponent animationComponent,
        NavMeshMove navMeshMove, float moveSpeed) : base(stateMachine)
    {
        _pointGetter = pointGetter;
        _navMeshMove = navMeshMove;
        _moveSpeed = moveSpeed;
        _animationComponent = animationComponent;
    }

    public override void LogicUpdate()
    {
        if (_navMeshMove.IsClose == false) return;
        Machine.ChangeState<EnemyIdle>();
    }

    public override void Enter()
    {
        _animationComponent.PlayAnimation(UnitAnimations.Run);
        _point = _pointGetter.GetPoint();
        _navMeshMove.SetMoveDestination(_point.position, _moveSpeed);
    }

    public override void Exit()
    {
        _animationComponent.PlayAnimation(UnitAnimations.Idle);
        _pointGetter.ReturnPoint(_point);
    }
}