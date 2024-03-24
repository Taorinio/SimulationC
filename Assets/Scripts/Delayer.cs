using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delayer : MonoBehaviour
{
    public Image DelayIcon;
    public Caster CasterFrom;
    float _timer;
    void Update()
    {
        _timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && CasterFrom.CanShoot) {
            _timer = 0;
        }
        _timer = Mathf.Clamp(_timer, 0, CasterFrom.Delay);
        DelayIcon.fillAmount = 1 - (_timer / CasterFrom.Delay);
    }
}
