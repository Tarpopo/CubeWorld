using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public abstract class BaseTweenAnimation : ITween
{
    public bool Join => _join;
    public float Duration => _duration;
    [SerializeField] private bool _join;
    [SerializeField] private float _duration;
    private Tween _tween;

    public abstract Tween GetTween();

    public void PlayAnimation()
    {
        SetStartValues();
        GetTween().TryPlayTween(ref _tween);
    }

    public void PlayForward(Action onComplete = null)
    {
        if (_tween == null)
        {
            SetStartValues();
            _tween = GetTween();
            _tween.SetAutoKill(false);
        }

        else _tween.PlayForward();

        _tween.onPause = () => onComplete?.Invoke();
    }

    public void PlayBackwards(Action onComplete = null)
    {
        _tween.PlayBackwards();
        _tween.onPause = () => onComplete?.Invoke();
    }

    public virtual void OnStart()
    {
    }

    public abstract void SetStartValues();

    public abstract void SetEndValues();
}