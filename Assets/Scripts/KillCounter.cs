using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public int Kills = 0;
    public Mover Door;
    public Mover Door2;
    void Update()
    {
        if (Kills == 4) {
            Door.MoveToBefore();
        }
        if (Kills == 44) {
            Door2.MoveToBefore();
        }
    }
}
