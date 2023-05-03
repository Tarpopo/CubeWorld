using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public abstract class BaseUnit : MonoBehaviour
{
    [SerializeField, TabGroup("Refs")] protected AnimationComponent _animationComponent;
    [SerializeField, TabGroup("Refs")] protected NavMeshMove _navMeshMove;

    // protected StateMachine _stateMachine;
    // protected IMove _move;
    // protected IRotateMove _rotateMove;
    // protected AnimationComponent _animationComponent;


    protected virtual void Start()
    {
        // _stateMachine = new StateMachine();
        // _move = GetComponent<IMove>();
        // _rotateMove = GetComponent<IRotateMove>();
        // _animationComponent = GetComponent<AnimationComponent>();
    }

    // private void Update() => _stateMachine.CurrentState.LogicUpdate();
    //
    // private void FixedUpdate() => _stateMachine.CurrentState.PhysicsUpdate();
}