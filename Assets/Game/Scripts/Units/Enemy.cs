using UnityEngine;

public class Enemy : BaseUnit
{
    protected override void Start()
    {
        base.Start();
        _stateMachine.AddState(new Idle(_stateMachine));
        _animationComponent.PlayAnimation(UnitAnimations.Idle);
        _stateMachine.Initialize<Idle>();
    }

    // private void OnTriggerEnter(Collider other) => _resourceChecker.OnTriggerEnter(other);
    //
    // private void OnTriggerStay(Collider other) => _resourceChecker.OnTriggerStay(other);
    //
    // private void OnTriggerExit(Collider other) => _resourceChecker.OnTriggerExit(other);
}