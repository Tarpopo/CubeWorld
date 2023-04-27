using System;
using UnityEngine;

public class MeshParticles : MonoBehaviour
{
    [SerializeField] private Animation _animation;
    [SerializeField] private AnimationClip _showHideAnimation;
    [SerializeField] private MeshParticlesPool _pool;

    private void OnEnable() => _animation.Play(_showHideAnimation.name);

    public void DisableParticle()
    {
        _pool.Return(this);
    }
}