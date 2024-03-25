using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public PlayerHealth Player;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player" || other.gameObject.tag == "box") {
            Player.Kill();
        }
    }
}
