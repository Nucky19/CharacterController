using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour
{
        private CharacterController _characterController;
    private Transform _camera;

     //----------------Variables Movimiento-----------------
    [SerializeField] private float _movementSpeed = 5;
    private float _horizontal;
    private float _vertical;
    [SerializeField] private float _turnSmoothTime=0.1f;
    [SerializeField] private float _jumpHeight=1; 

    //----------------Variables Gravedad--------------------
    [SerializeField] private float _gravity=-9.81f;
    [SerializeField] private Vector3 _playergravity;

    //----------------Variables GroundSensor----------------
    [SerializeField] LayerMask _floorLayer;
    [SerializeField] Transform _sensorPosition;
    [SerializeField] float _sensorRadius=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
