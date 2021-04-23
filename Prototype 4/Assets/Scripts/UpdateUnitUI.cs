using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUnitUI : MonoBehaviour
{
    public TMP_Text nameUI,a,p,c,turns;   
    void Awake()
    {
        nameUI.text = gameObject.name.Split('(')[0];
        a.text = $"{GetComponent<Aspect>().a}";
        p.text = $"{GetComponent<Aspect>().p}";
        c.text = $"{GetComponent<Aspect>().l}";
    }
    private void FixedUpdate()
    {
        turns.text = $"{GetComponent<Unit>().timeToRecovery}";
    }
}

