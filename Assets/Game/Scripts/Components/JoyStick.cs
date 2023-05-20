using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Vector2 JoystickDirection { get; private set; }
    [SerializeField] private OnRoll _onRollEvent;
    [SerializeField] private JoystickSO _joystickSo;
    [SerializeField] private RectTransform _canvas;
    [SerializeField] private RectTransform _outsideCircle;
    [SerializeField] private RectTransform _insideCircle;
    [SerializeField] private RectTransform _arrowTransform;
    [SerializeField] private GameObject _cicle;
    [SerializeField] private GameObject _arrow;
    private Vector2 _startPosition;

    private void Start() => DisableJoystick();

    private void EnableJoystick() => _outsideCircle.gameObject.SetActive(true);

    private void DisableJoystick()
    {
        _outsideCircle.gameObject.SetActive(false);
        ResetPositions();
    }

    private void ResetPositions() => _insideCircle.localPosition = Vector3.zero;

    public void OnPointerDown(PointerEventData eventData)
    {
        EnableJoystick();
        _outsideCircle.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        _startPosition = eventData.position;
        SetActiveInside(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if ((eventData.position - _startPosition).magnitude > _joystickSo.RadiusInsideCircle) _onRollEvent.Invoke();
        DisableJoystick();
    }

    public void OnDrag(PointerEventData eventData)
    {
        JoystickDirection = eventData.position - _startPosition;
        var magnitude = JoystickDirection.magnitude;
        var position = JoystickDirection.normalized * Mathf.Clamp(magnitude, 0, _joystickSo.RadiusInsideCircle);
        _insideCircle.anchoredPosition = position;
        _arrowTransform.anchoredPosition = position;
        SetActiveInside(magnitude < _joystickSo.RadiusInsideCircle);
        SetArrowRotate(JoystickDirection.normalized);
    }

    private void SetActiveInside(bool touchInside)
    {
        _cicle.SetActive(touchInside);
        _arrow.SetActive(!touchInside);
    }

    private void SetArrowRotate(Vector2 direction) => _arrowTransform.right = direction;

    private Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition) =>
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas, screenPosition, Helpers.Camera,
            out var localPoint)
            ? localPoint
            : Vector2.zero;
}