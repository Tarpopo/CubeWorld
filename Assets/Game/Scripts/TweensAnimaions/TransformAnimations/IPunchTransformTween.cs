using DG.Tweening;
using UnityEngine;

public interface IPunchTransformTween
{
    Tween GetPunchScaleTween(Vector3 value, float duration, int vibrato, float elasticity);

    Tween GetPunchRotationTween(Quaternion value, float duration, int vibrato, float elasticity);
}