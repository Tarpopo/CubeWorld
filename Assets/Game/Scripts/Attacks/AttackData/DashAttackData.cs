using UnityEngine;

[CreateAssetMenu(menuName = "Data/Attack/" + nameof(DashAttackData))]
public class DashAttackData : BaseAttackData
{
    public float DashTime => _dashTime;
    public float DashSpeed => _dashSpeed;
    [SerializeField] private float _dashTime;
    [SerializeField] private float _dashSpeed;
}