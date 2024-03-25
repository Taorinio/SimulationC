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
    AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        delayer = GetComponent<Delayer>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && CanShoot) {
            _audioSource.Play();
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
