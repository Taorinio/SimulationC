using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public RectTransform Value;
    public float Health = 100f;
    public GameObject GameOver;
    public List<GameObject> UI;
    void Update()
    {
        if (Health <= 0) {
            Kill();
        }
    }
    public void DealDamage(float Damage) {
        Health -= Damage;
        UpdateValue();
    }
    public void Kill() {
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerHealth>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        GetComponent<Caster>().enabled = false;
        GameOver.SetActive(true);
        foreach (GameObject i in UI) {
            i.SetActive(false);
        }
    }
    void UpdateValue() {
        Value.anchorMax = new Vector2(Health / 100f, 1f);
    }
}
