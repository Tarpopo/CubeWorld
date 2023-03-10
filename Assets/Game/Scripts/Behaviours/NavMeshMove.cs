using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshMove : MonoBehaviour, IMove
{
    [SerializeField] private NavMeshAgent _navMeshAgent;

    public void Move(Vector3 direction, float moveSpeed)
    {
        if (_navMeshAgent.isActiveAndEnabled) _navMeshAgent.Warp(direction);
    }

    public void StopMove() => _navMeshAgent.enabled = false;

    private void OnEnable() => _navMeshAgent.enabled = true;

    private void OnDisable() => _navMeshAgent.enabled = false;
}