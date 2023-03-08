using System;
using UnityEngine;

public interface ICollectableResource : IResource
{
    public GameObject Resource { get; }
    bool Collecting { get; }
    public void Collect(Transform collectPoint, float collectDelay, Action onCollect);
}