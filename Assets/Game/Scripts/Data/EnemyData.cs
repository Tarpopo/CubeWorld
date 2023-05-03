using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyData")]
[InlineEditor]
public class EnemyData : BaseUnitData
{
    public DashAttackData DashAttackData => _dashAttackData;
    public NotifierData NotifierData => _notifierData;

    [SerializeField] private DashAttackData _dashAttackData;
    [SerializeField] private NotifierData _notifierData;
}