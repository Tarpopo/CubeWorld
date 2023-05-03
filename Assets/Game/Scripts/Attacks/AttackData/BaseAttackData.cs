using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Attack/" + nameof(BaseAttackData))]
[InlineEditor]
public class BaseAttackData : ScriptableObject
{
    public int Damage => _damage;
    public float AttackRadius => _attackRadius;
    public float AttackStartDistance => _attackStartDistance;
    public float AttackStartDelay => _attackStartDelay;
    public string DamageableTag => _damageableTag;
    public Color GizmosColor => _gizmosColor;
    public UnitAnimations AttackAnimation => _attackAmination;

    [SerializeField] private int _damage;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackStartDistance;
    [SerializeField] private float _attackStartDelay;
    [SerializeField, Tag] private string _damageableTag;
    [SerializeField] private UnitAnimations _attackAmination;
    [SerializeField] private Color _gizmosColor;
}