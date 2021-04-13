using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateResponseUI : MonoBehaviour
{
    public TMP_Text textUI,a,p,c;
    public GameObject loss, win, exhaust, insert;
    Effect effect;
    Aspect aspect;
    void Awake()
    {
        effect = GetComponent<Effect>();
        aspect = GetComponent<Aspect>();

        textUI.text = gameObject.name.Split('(')[0];
        a.text = $"{aspect.a}";
        p.text = $"{aspect.p}";
        c.text = $"{aspect.l}";


        if (effect.loss)
            loss.SetActive(true);
        if (effect.win)
            win.SetActive(true);
        if (effect.exhaustable)
            exhaust.SetActive(true);
        if (effect.insertEvent != null)
            insert.SetActive(true);
    }
}
