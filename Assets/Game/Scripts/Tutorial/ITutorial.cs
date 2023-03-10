using System;
using UnityEngine;

public interface ITutorial
{
    public event Action OnComplete;
    Transform TutorialPoint { get; }
    string TutorialText { get; }
    void SetTutorialParameters();
    void EnableTutorial();
    void DisableTutorial();
}