using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public List<ProgressTable> ProgressList;
    public RectTransform ValueRect;
    public Text LevelValue;
    public int Level;
    float _progressValue;
    Caster ScriptParams;
    void Start()
    {
        ScriptParams = GetComponent<Caster>();
        ScriptParams.Damage = ProgressList[Level].Damage;
        ScriptParams.Delay = ProgressList[Level].Delay;
    }
    void Update()
    {
        Progresser();
    }
    void Progresser() {
        if (_progressValue >= ProgressList[Level].LevelRequirement) {
            Level += 1;
            _progressValue = 0;
            ScriptParams.Damage = ProgressList[Level].Damage;
            ScriptParams.Delay = ProgressList[Level].Delay;
            LevelValue.text = (Level + 1).ToString();
        }
    }
    public void AddProgress(float Value) {
        _progressValue += Value;
        ValueRect.anchorMax = new Vector2(1, _progressValue / ProgressList[Level].LevelRequirement);
    }
}
