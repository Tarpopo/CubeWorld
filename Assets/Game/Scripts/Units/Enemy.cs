using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class Enemy : BaseUnit, ICameraVisibleCheck
{
    public bool Visible { get; private set; }
    public event Action OnVisible;
    public event Action OnInvisible;
    public float IdleTime => _enemyData.IdleTime;
    public float StartDashAttackDelay => _enemyData.DashAttackData.AttackStartDelay;
    public float AfterDashDelay => _enemyData.DashAttackData.AfterDashDelay;
    public float DashStartDistance => _enemyData.DashAttackData.AttackStartDistance;
    public EnemyData EnemyData => _enemyData;
    public AttackNotifier AttackNotifier { get; private set; }
    public DashAttack DashAttack { get; private set; }

    [SerializeField, TabGroup("Data")] private EnemyData _enemyData;
    [SerializeField, TabGroup("Refs")] private PointGetter _pointGetter;
    [SerializeField, TabGroup("Refs")] private Transform _attackNotifyPoint;

    public void InvokeOnVisible()
    {
        OnVisible?.Invoke();
        Visible = true;
    }

    public void InvokeOnInvisible()
    {
        OnInvisible?.Invoke();
        Visible = false;
    }

    private void Awake()
    {
        DashAttack = new DashAttack(_enemyData.DashAttackData, transform, this);
        AttackNotifier = new AttackNotifier(_enemyData.NotifierData, _attackNotifyPoint);
    }

    private void OnEnable()
    {
        DashAttack.OnStartAttack += _navMeshMove.DisableNavmesh;
        DashAttack.OnStopAttack += _navMeshMove.EnableNavMesh;
    }

    private void OnDisable()
    {
        DashAttack.OnStartAttack -= _navMeshMove.DisableNavmesh;
        DashAttack.OnStopAttack -= _navMeshMove.EnableNavMesh;
    }
}