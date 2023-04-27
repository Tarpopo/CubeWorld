using UnityEngine;

[CreateAssetMenu(menuName = "Data/Attack/" + nameof(DashAttackData))]
public class DashAttackData : BaseAttackData
{
    public float DashTime => _dashTime;
    public float DashSpeed => _dashSpeed;
    public float DashDuration => _dashDuration;
    public float DashDistance => _dashDistance;
    public float YMultiply => _yMultiply;

    public AnimationCurve YCurve => _yCurve;

    [SerializeField] private float _dashTime;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashDuration;
    [SerializeField] private float _dashDistance;
    [SerializeField] private float _yMultiply;
    [SerializeField] private AnimationCurve _yCurve;
}