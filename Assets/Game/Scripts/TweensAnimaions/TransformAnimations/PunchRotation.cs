using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class PunchRotation : BaseTweenAnimation
{
    [SerializeField] private Quaternion _punchRotation;
    [SerializeField] private int _vibrato;
    [SerializeField] private float _elasticity;
    [SerializeReference] private IPunchTransformTween _transformTween;

    public override Tween GetTween() =>
        _transformTween.GetPunchRotationTween(_punchRotation, Duration, _vibrato, _elasticity);

    public override void SetStartValues()
    {
    }

    public override void SetEndValues()
    {
    }
}