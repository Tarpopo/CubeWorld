using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class PunchScale : BaseTweenAnimation
{
    [SerializeField] private Vector3 _punch = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField] private int _vibrato = 10;
    [SerializeField] private float _elasticity = 10;
    [SerializeReference] private IPunchTransformTween _transformTween;

    public override Tween GetTween() => _transformTween.GetPunchScaleTween(_punch, Duration, _vibrato, _elasticity);

    public override void SetStartValues()
    {
    }

    public override void SetEndValues()
    {
    }
}