using UnityEngine;

public class Enemy : BaseUnit
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private PointGetter _pointGetter;

    protected override void Start()
    {
        base.Start();
        _stateMachine.AddState(new Idle(_stateMachine));
        _stateMachine.AddState(new EnemyIdle(_stateMachine, _enemyData.IdleTime));
        _stateMachine.AddState(new EnemyMove(_stateMachine, _pointGetter, _animationComponent, (NavMeshMove)_move,
            _enemyData.MoveSpeed));
        _animationComponent.PlayAnimation(UnitAnimations.Idle);
        _stateMachine.Initialize<EnemyIdle>();
    }

    // private void OnTriggerEnter(Collider other) => _resourceChecker.OnTriggerEnter(other);
    //
    // private void OnTriggerStay(Collider other) => _resourceChecker.OnTriggerStay(other);
    //
    // private void OnTriggerExit(Collider other) => _resourceChecker.OnTriggerExit(other);
}