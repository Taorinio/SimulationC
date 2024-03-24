using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public PlayerController Player;
    GameObject _box;
    Rigidbody _boxRb;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject != null && other.gameObject.CompareTag("box") && Input.GetMouseButton(1)) {
            Player.GetBox(true, other.gameObject);
            if (other.gameObject != _box) {
                _box = other.gameObject;
                _boxRb = _box.GetComponent<Rigidbody>(); // Получаем компонент Rigidbody у _box
                _boxRb.isKinematic = true;
            }
        }
        else if (other.gameObject == null || !Input.GetMouseButton(1)) {
            Player.GetBox(false, null);
            if (_box != null) {
                _boxRb.isKinematic = false; // Сбрасываем isKinematic при отпускании
                _box = null; // Сбрасываем ссылку на _box
                _boxRb = null; // Сбрасываем ссылку на _boxRb
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject != null && other.gameObject.CompareTag("box")) {
            Player.GetBox(false, null);
            if (_box != null) {
                _boxRb.isKinematic = false;
                _box = null;
                _boxRb = null;
            }
        }
    }
}
