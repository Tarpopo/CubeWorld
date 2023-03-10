using System;
using System.Collections;
using UnityEngine;

public class CollectableResource : MonoBehaviour, ICollectableResource
{
    public GameObject Resource => gameObject;
    public bool Collecting { get; private set; }
    public ResourceType ResourceType => _resourceType;

    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private float _flyDuration = 0.5f;
    [SerializeField] private float _onCollectJumpForce;
    private Rigidbody _rigidbody;

    public void Collect(Transform collectPoint, float collectDelay, Action onCollect)
    {
        Collecting = true;
        StartCoroutine(MoveCoroutine(collectPoint, collectDelay, _flyDuration, onCollect));
    }

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void OnEnable() => Collecting = false;

    private IEnumerator MoveCoroutine(Transform endPoint, float delay, float moveSpeed,
        Action onEnd = null)
    {
        _rigidbody.SetGravity(true);
        _rigidbody.velocity = Vector3.up * _onCollectJumpForce;
        yield return new WaitForSeconds(delay);
        _rigidbody.SetGravity(false);
        while (Vector3.Distance(transform.position, endPoint.position) > 0.5f)
        {
            transform.position = Vector3.Lerp(transform.position, endPoint.position, Time.fixedDeltaTime / moveSpeed);
            yield return new WaitForFixedUpdate();
        }

        _rigidbody.SetGravity(true);
        onEnd?.Invoke();
    }
}