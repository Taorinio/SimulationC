using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delayer : MonoBehaviour
{
    public Image DelayIcon;
    public Caster CasterFrom;
    public float Timer;
    void Update()
    {
        Timer += Time.deltaTime;
        Timer = Mathf.Clamp(Timer, 0, CasterFrom.Delay);
        DelayIcon.fillAmount = 1 - (Timer / CasterFrom.Delay);
    }
}
