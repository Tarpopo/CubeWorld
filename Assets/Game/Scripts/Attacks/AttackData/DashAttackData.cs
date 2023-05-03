using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Attack/" + nameof(DashAttackData))]
[InlineEditor]
public class DashAttackData : BaseAttackData
{
    public float DashDuration => _dashDuration;
    public float DashDistance => _dashDistance;
    public float AfterDashDelay => _afterDashDelay;
    public float YMultiply => _yMultiply;
    public AnimationCurve YCurve => _yCurve;

    [SerializeField] private float _afterDashDelay;
    [SerializeField] private float _dashDuration;
    [SerializeField] private float _dashDistance;
    [SerializeField] private float _yMultiply;
    [SerializeField] private AnimationCurve _yCurve;
}