using UnityEngine;

public class BaseUnitData : ScriptableObject
{
    public float IdleTime => _idleTime.Value;
    public float MoveSpeed => _moveSpeed;
    [SerializeField] private FloatRandomValue _idleTime;
    [SerializeField] private float _moveSpeed;
}