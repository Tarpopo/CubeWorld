using System;
using UnityEngine;

[Serializable]
public abstract class BaseTutorial : ITutorial
{
    public event Action OnComplete;
    public Transform TutorialPoint => _tutorialPoint;
    public string TutorialText => _tutorialText;
    [SerializeField] private Transform _tutorialPoint;
    [SerializeField] private string _tutorialText;
    public abstract void SetTutorialParameters();
    public abstract void EnableTutorial();
    public abstract void DisableTutorial();
    protected virtual void CompleteTutorial() => OnComplete?.Invoke();
}