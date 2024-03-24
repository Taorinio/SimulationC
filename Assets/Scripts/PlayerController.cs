using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float gravity = 9.81f;

    private float _fallVelocity = 0f;

    private CharacterController _characterController;

    public float jumpForce;

    public float speed;
    public float BreathHeight = 0.001f;
    public float BreathSpeed = 2f;
    public List<Transform> BreathEffect;
    float _timer = 0;
    private Vector3 _moveVector;
    bool _isTaking;
    GameObject _box;
    public Transform GrabZone;
    

    void Update ()
    {
        foreach (Transform i in BreathEffect) {
            i.position += new Vector3(0, BreathHeight * Mathf.Sin(_timer * BreathSpeed), 0);
        }
        _timer += Time.deltaTime;
        if (_timer > 2 * Mathf.PI) {
            _timer = 0;
        } 
        Grab();
        // Movement
        Movement();
        // Jump
        JumpUpdate();
    }

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void FixedUpdate()
    {
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);


        // Fall and Jump
        _fallVelocity += gravity * Time.fixedDeltaTime;

        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
    void Movement() {
        _moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
    }
    void JumpUpdate() {
        if (Input.GetKey(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }
    public void GetBox(bool collision, GameObject box) {
        _isTaking = collision;
        _box = box;
    }
    void Grab() {
        if (_box != null) { 
            _box.transform.position = GrabZone.position;
            _box.transform.rotation = Quaternion.Euler(0, GrabZone.rotation.y, 0);
        }
    }
}
