using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public Image LightScreen;
    bool _isWon;
    public float Speed = 1f;
    public GameObject WonScreen;
    void Update()
    {
        if (_isWon) {
            if (LightScreen.color.a < 1f) {
                LightScreen.color += Color.white * Speed * Time.deltaTime;
            }
            else {
                WonScreen.SetActive(true);
            }
        }
    }
    public void ShowWin() {
        _isWon = true;
    }
}
