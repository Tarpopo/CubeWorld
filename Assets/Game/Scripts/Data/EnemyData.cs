using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float IdleTime => _idleTime;
    [SerializeField] private float _idleTime;
    public float NavMeshSpeed => _navMeshSpeed;
    [SerializeField] private float _navMeshSpeed;
}