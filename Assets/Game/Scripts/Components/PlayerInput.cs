using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public bool IsMouseDown { get; private set; }
    public bool IsMove => Input.GetMouseButton(0);
    public float Angle => AngleBetweenTwoPoints(_startPosition, _endPosition);
    public float Distance => Vector2.Distance(_startPosition, _endPosition);
    public Vector3 MoveDirection => _endPosition - _startPosition;
    [SerializeField] private float _activeRadius;
    [SerializeField] private UnityEvent _onMove;
    [SerializeField] private UnityEvent _onTouchDown;
    [SerializeField] private UnityEvent _onTouchUp;
    [SerializeField] private InputActionAsset _mobile;
    private Vector2 _startPosition;
    private Vector2 _endPosition;

    public event UnityAction OnMove
    {
        add => _onMove.AddListener(value);
        remove => _onMove.RemoveListener(value);
    }

    public event UnityAction OnTouchDown
    {
        add => _onTouchDown.AddListener(value);
        remove => _onTouchDown.RemoveListener(value);
    }

    public event UnityAction OnTouchUp
    {
        add => _onTouchUp.AddListener(value);
        remove => _onTouchUp.RemoveListener(value);
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b) => Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;

    private void OnEnable()
    {
        _mobile.Enable();
    }

    private void OnDisable()
    {
        _mobile.Disable();
    }

    private void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     _startPosition = Input.mousePosition;
        //     _endPosition = Input.mousePosition;
        //     _onTouchDown?.Invoke();
        //     IsMouseDown = true;
        // }
        //
        // if (Input.GetMouseButton(0))
        // {
        //     if (Distance > _activeRadius) _onMove?.Invoke();
        //     _endPosition = Input.mousePosition;
        // }
        //
        // if (Input.GetMouseButtonUp(0))
        // {
        //     _onTouchUp?.Invoke();
        //     IsMouseDown = false;
        // }
    }
}