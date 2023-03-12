using System;
using UnityEngine;

public class TweenContainer : MonoBehaviour
{
    [SerializeField] private bool _setStartValuesOnEnable;
    [SerializeReference] private BaseTweenAnimation _tweenAnimation;

    private void OnEnable()
    {
        if (_setStartValuesOnEnable) _tweenAnimation.SetStartValues();
    }

    public void Play() => _tweenAnimation.PlayAnimation();
}