using Sirenix.OdinInspector;
using UnityEngine;

public class TestVector : MonoBehaviour
{
    [Button]
    private void ShowForward() => print(transform.forward);

    [Button]
    private void ShowCameraForward(Vector3 vector3) => print(Camera.main.transform.forward);

    [Button]
    private void ChangeForward(Vector3 vector3) => transform.forward = vector3;
}