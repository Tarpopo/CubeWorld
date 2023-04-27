using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshMove : MonoBehaviour, IMove
{
    public bool IsClose => _navMeshAgent.pathPending == false &&
                           _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance;

    [SerializeField] private NavMeshAgent _navMeshAgent;

    public void Move(Vector3 direction, float moveSpeed)
    {
        if (_navMeshAgent.isActiveAndEnabled) _navMeshAgent.Warp(direction);
    }

    public void SetMoveDestination(Vector3 point, float moveSpeed)
    {
        _navMeshAgent.speed = moveSpeed;
        _navMeshAgent.SetDestination(point);
    }

    public void StopMove()
    {
        if (_navMeshAgent.isOnNavMesh) _navMeshAgent.ResetPath();
    }

    private void OnEnable() => _navMeshAgent.enabled = true;

    private void OnDisable() => _navMeshAgent.enabled = false;
}