using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MusicEvent : MonoBehaviour
{
    [SerializeField] private int _songLenght;
    [SerializeField] private int _secondsEvent;
    [SerializeField] private UnityEvent _onEvent;

    private void Start() => StartCoroutine(StartTimer());

    private IEnumerator StartTimer()
    {
        for (int i = 0; i < _songLenght; i++)
        {
            if (i == _secondsEvent) _onEvent?.Invoke();
            float time = 0;
            while (time <= 1)
            {
                time += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
        }
    }
}