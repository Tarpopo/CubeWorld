using DG.Tweening;

public interface ITween
{
    public bool Join { get; }
    public float Duration { get; }
    Tween GetTween();
}