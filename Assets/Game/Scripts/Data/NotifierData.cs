using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/" + nameof(NotifierData))]
[InlineEditor]
public class NotifierData : ScriptableObject
{
    public MeshParticlesPool MeshParticlesPool => _meshParticlesPool;
    public float NotifyDelay => _norifyDelay;
    [SerializeField] private MeshParticlesPool _meshParticlesPool;
    [SerializeField] private float _norifyDelay;
}