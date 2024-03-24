using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public GameObject PixelballPrefab;
    public Transform PixelCaster;
    public Transform Target;
    public float Delay;
    public bool CanShoot = true;
    void Update()
    {
        if (Input.GetMouseButton(0) && CanShoot) {
            var Pixelball = Instantiate(PixelballPrefab, PixelCaster.position, Quaternion.identity);
            Pixelball.transform.LookAt(Target.position);
            Prohibit();
        }
    }
    void Prohibit() {
        CanShoot = false;
        Invoke("Allow", Delay);
    }
    void Allow() {
        CanShoot = true;
    }
}
