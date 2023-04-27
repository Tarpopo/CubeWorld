using UnityEngine;

public class BaseUnitData : ScriptableObject
{
    public float IdleTime => _idleTime;
    public float MoveSpeed => _moveSpeed;
    [SerializeField] private float _idleTime;
    [SerializeField] private float _moveSpeed;
}