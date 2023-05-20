using System;
using UnityEngine;

[Serializable]
public class AnimationComponent
{
    public Enum Animations => _animations;
    [SerializeReference] private Enum _animations;
    [SerializeField] private Animator _animator;

    public void PlayAnimation(Enum animationType) => _animator.Play(animationType.ToString());
    public void PlayAnimation(string animationName) => _animator.Play(animationName, 0);
    public void PlayAnimation(AnimationClip clip) => _animator.Play(clip.name);

    private void OnEnable() => _animator.enabled = true;

    private void OnDisable() => _animator.enabled = false;
}

public enum UnitAnimations
{
    Idle,
    Run,
    AxeAttack,
    PickAttack,
    TakeDamage,
    Death,
    AttackSit,
    AttackJump,
    Landing,
    Getup
}

public enum SpotsAnimations
{
    Idle,
    Active,
}