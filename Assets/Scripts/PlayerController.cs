using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController _characterController;
    [SerializeField] private float _movementSpeed = 5;
    private float _horizontal;
    private float _vertical;
    private float _turnSmoothVelocity;
    [SerializeField] private float _turnSmoothTime=0.1f;
    //----------------Variables Gravedad--------------------
    [SerializeField] private float _gravity=-9.81f;
    [SerializeField] private Vector3 _playergravity;

    //----------------Variables GroundSensor----------------
    [SerializeField] LayerMask _floorLayer;
    [SerializeField] Transform _sensorPosition;
    [SerializeField] float _sensorRadius=0.5f;
    
    void Start()
    {
        
    }
    void Awake(){
        _characterController = GetComponent<CharacterController>();
    }
    void Update(){
        _horizontal=Input.GetAxis("Horizontal");
        _vertical=Input.GetAxis("Vertical");
        Movement();
        Gravity();
    }
    void Movement(){
        Vector3 direction= new Vector3(_horizontal, 0, _vertical);
        if(direction != Vector3.zero){
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
            _characterController.Move(direction *_movementSpeed *Time.deltaTime);
        }
    }
    void Gravity(){
        if(!IsGrounded()) _playergravity.y += _gravity *Time.deltaTime;
        else if(IsGrounded() && _playergravity.y <0) _playergravity.y=-1;
        
        _characterController.Move(_playergravity *Time.deltaTime);
    }
    bool IsGrounded(){
        return Physics.CheckSphere(_sensorPosition.position, _sensorRadius, _floorLayer);
    }
    void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_sensorPosition.position, _sensorRadius);
    }
}