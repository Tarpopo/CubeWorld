using UnityEngine;

public class CameraVisibleChecker : MonoBehaviour
{
    private TriggerChecker<ICameraVisibleCheck> _triggerChecker;

    private void Awake() => _triggerChecker = new TriggerChecker<ICameraVisibleCheck>();

    private void OnEnable()
    {
        _triggerChecker.OnObjectEnter += OnEnter;
        _triggerChecker.OnObjectExit += OnExit;
    }

    private void OnDisable()
    {
        _triggerChecker.OnObjectEnter -= OnEnter;
        _triggerChecker.OnObjectExit -= OnExit;
    }

    private void OnEnter(ICameraVisibleCheck cameraVisibleCheck) => cameraVisibleCheck.InvokeOnVisible();

    private void OnExit(ICameraVisibleCheck cameraVisibleCheck) => cameraVisibleCheck.InvokeOnInvisible();

    private void OnTriggerEnter(Collider other) => _triggerChecker.OnTriggerEnter(other);

    private void OnTriggerExit(Collider other) => _triggerChecker.OnTriggerExit(other);

    private void OnTriggerStay(Collider other) => _triggerChecker.OnTriggerStay(other);
}