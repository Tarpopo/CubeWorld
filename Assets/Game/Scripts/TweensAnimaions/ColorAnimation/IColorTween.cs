using DG.Tweening;
using UnityEngine;

public interface IColorTween
{
    Color Color { get; }
    void SetColor(Color color);
    Tween GetTween(Color color, float duration);
}