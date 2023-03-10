using System;
using DG.Tweening;
using UnityEngine;
using Image = UnityEngine.UI.Image;

[Serializable]
public class ImageColor : IColorTween
{
    public Color Color => _image.color;
    [SerializeField] private Image _image;

    public Tween GetTween(Color color, float duration) => _image.DOColor(color, duration);

    public void SetColor(Color color) => _image.color = color;
}