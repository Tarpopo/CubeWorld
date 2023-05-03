using System;

public interface ICameraVisibleCheck
{
    bool Visible { get; }
    event Action OnVisible;
    event Action OnInvisible;
    void InvokeOnVisible();
    void InvokeOnInvisible();
}