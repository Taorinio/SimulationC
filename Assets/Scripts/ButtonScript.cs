using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent OnPress;
    public UnityEvent OnDispress;
    public GameObject Box;
    public float Speed = 1f;
    bool _isPressed;
    void Update()
    {
        if (_isPressed && transform.localPosition.y > 0.05f) {
            transform.position -= new Vector3(0, Speed * Time.deltaTime, 0);
        }
        else if (!_isPressed && transform.localPosition.y < 0.2f) {
            transform.position += new Vector3(0, Speed * Time.deltaTime, 0);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == Box.tag) {
            OnPress.Invoke();
            _isPressed = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == Box.tag) {
            OnDispress.Invoke();
            _isPressed = false;
        }
    }
}
