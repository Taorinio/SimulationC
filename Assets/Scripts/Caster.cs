using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public GameObject PixelballPrefab;
    Delayer delayer;
    public Transform PixelCaster;
    public Transform Target;
    public float Delay = 9.3f;
    public float Damage = 25f;
    public bool CanShoot = true;
    void Start()
    {
        delayer = GetComponent<Delayer>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanShoot) {
            delayer.Timer = 0;
            var Pixelball = Instantiate(PixelballPrefab, PixelCaster.position, Quaternion.identity);
            Pixelball.transform.LookAt(Target.position);
            Pixelball.GetComponent<Fireball>().Damage = Damage;
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
