using TMPro;
using UnityEngine;

public class TutorialSetter : MonoBehaviour
{
    [SerializeReference] private ITutorial[] _tutorials;
    [SerializeField] private TMP_Text _tmp;
    [SerializeField] private PointMover _pointMover;
    private int _currentTutorialIndex;

    private void Awake()
    {
        foreach (var tutorial in _tutorials) tutorial.SetTutorialParameters();
    }

    private void OnEnable()
    {
        _currentTutorialIndex = 0;
        foreach (var tutorial in _tutorials)
        {
            tutorial.OnComplete += TryChangeTutorial;
            tutorial.DisableTutorial();
        }

        EnableTutorial();
    }

    private void OnDisable()
    {
        foreach (var tutorial in _tutorials)
        {
            tutorial.OnComplete -= TryChangeTutorial;
            tutorial.DisableTutorial();
        }
    }

    private void TryChangeTutorial()
    {
        if (_currentTutorialIndex >= _tutorials.Length - 1)
        {
            gameObject.Disable();
            return;
        }

        _tutorials[_currentTutorialIndex].DisableTutorial();
        _currentTutorialIndex++;
        EnableTutorial();
    }

    private void EnableTutorial()
    {
        _tutorials[_currentTutorialIndex].EnableTutorial();
        _pointMover.SetFollowPoint(_tutorials[_currentTutorialIndex].TutorialPoint);
        UpdateText();
    }

    private void UpdateText() => _tmp.text = _tutorials[_currentTutorialIndex].TutorialText;
}