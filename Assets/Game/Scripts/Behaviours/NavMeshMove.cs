using UnityEngine;
using UnityEngine.AI;

public class NavMeshMove : MonoBehaviour, IMove
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    public void Move(Vector3 direction, float moveSpeed) => _navMeshAgent.Warp(direction);

    public void StopMove()
    {
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }
}