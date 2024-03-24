using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform PositionAfter;
    public Transform PositionBefore;
    public float Speed = 1f;
    string[] _positions = new string[] {"after", "-", "before"};
    string _position = "-";
    void Update()
    {
        switch (_position) {
            case "after":
                transform.position = Vector3.MoveTowards(transform.position, PositionAfter.position, Time.deltaTime * Speed);
                if (transform.position == PositionAfter.position) goto case "-";
                break;
            case "-":
                break;
            case "before":
                transform.position = Vector3.MoveTowards(transform.position, PositionBefore.position, Time.deltaTime * Speed);
                if (transform.position == PositionBefore.position) goto case "-";
                break;
        }
    }

    public void MoveToAfter() {
        _position = _positions[0];
    }
    public void MoveToBefore() {
        _position = _positions[2];
    }
    public void Default() {
        _position = _positions[1];
    }
}
