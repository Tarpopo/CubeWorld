using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rollDistance;
    [SerializeField] private float _angleOffset;
    [SerializeField] private float _rotationSpeed;
    private PlayerInput _playerInput;
    private float _distToCam;
    
    private Transform _transform;
    private Camera _camera;
    private Rigidbody _rigidBody;
    private Vector3 _beganPos;
    private Vector3 _moveDirection;
    private Vector3 _rayPos;
    private  void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.OnMove += () =>
        {
            _transform.rotation = Quaternion.AngleAxis(-_playerInput.Angle + _angleOffset, Vector3.up);
            //_transform.RotateAround(transform.position,transform.up,-_playerInput.Angle + _angleOffset);
            //_transform.rotation = Quaternion.AngleAxis(-_playerInput.Angle + _angleOffset, (transform.up).normalized);
            //_transform.rotation = new Quaternion(0, -_playerInput.Angle + _angleOffset, 0, 0);
            //Quaternion.AngleAxis(-_playerInput.Angle + _angleOffset, transform.up.normalized);
            //_rigidBody.MovePosition(_rigidBody.position+transform.forward*_speed);
            CheckGround();
        };
        _transform = transform;
        _rigidBody = GetComponent<Rigidbody>();
        _camera=Camera.main;
    }

    private void RotateToPlane()
    {
        transform.rotation*=Quaternion.Euler(90,0,0);
    }

    private void CheckGround()
    {
        if (Physics.Raycast(transform.position, -transform.up, 10) == false) 
        {
            //RotateToPlane();
            print("ground");
        }
    }

}
