using System;

public interface ICollector<T>
{
    public event Action<T> OnCollect;
}