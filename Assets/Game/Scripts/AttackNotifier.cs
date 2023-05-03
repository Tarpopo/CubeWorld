using UnityEngine;

public class AttackNotifier
{
    public float NotifyDelay => _data.NotifyDelay;
    private readonly NotifierData _data;
    private readonly Transform _particlePoint;

    public AttackNotifier(NotifierData data, Transform particlePoint)
    {
        _data = data;
        _data.MeshParticlesPool.Load();
        _particlePoint = particlePoint;
    }

    public void Notify() => _data.MeshParticlesPool.Get(_particlePoint.position);
}