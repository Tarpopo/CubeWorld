using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public abstract class BaseUnit : MonoBehaviour
{
    public NavMeshMove NavMeshMove { get; protected set; }
    public AnimationComponent AnimationComponent => _animationComponent;
    [SerializeField] protected AnimationComponent _animationComponent;
    protected virtual void Awake() => NavMeshMove = new NavMeshMove(GetComponent<NavMeshAgent>());
}