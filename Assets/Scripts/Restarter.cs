using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restarter : MonoBehaviour
{
    public SceneManage Player;
    void Update()
    {
        if (Input.anyKey) {
            Player.Restart();
        }
    }
}
