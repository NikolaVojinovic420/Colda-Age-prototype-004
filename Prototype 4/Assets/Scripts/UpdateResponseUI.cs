using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateResponseUI : MonoBehaviour
{
    public TMP_Text textUI,a,p,c;
    public GameObject loss, win, exhaust, insert, playable, forbiden;
    Effect effect;
    Aspect aspect;
    Response response;
    bool entered = false;
    void Awake()
    {
        effect = GetComponent<Effect>();
        aspect = GetComponent<Aspect>();
        response = GetComponent<Response>();

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
    void Update()
    {
        UpdatePlayable();
        UpdateForbidenToPlay();
    }
    void UpdatePlayable()
    {
        if (response.CurrentEngagedCanPay())
            playable.SetActive(true);
        else
            playable.SetActive(false);
    }
    void UpdateForbidenToPlay()
    {
        if (entered && response.gameObject.transform.parent.parent.tag == "EventStage")
            return;
        if (!entered && response.gameObject.transform.parent.parent.tag == "EventStage")
        {
            entered = true;
            if (!response.CurrentVigilantCanPay())
                forbiden.SetActive(true);
        }
        if (entered && response.gameObject.transform.parent.parent.tag != "EventStage")
        {
            entered = false;
            forbiden.SetActive(false);
        }
    }
}
