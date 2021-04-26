using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateResponseUI : MonoBehaviour
{
    public TMP_Text textUI, textExplainUI, a, p, c;
    public GameObject loss, win, playable, forbiden;

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

        textExplainUI.text = $"{effect.SetOneUpgradeText()}";
        if (effect.exhaustable)
            textExplainUI.text += $"\n- Exhaust this";
        if (effect.insertEvent != null)
            textExplainUI.text += $"\n- Insert new";
        if (effect.exhaustEvent)
            textExplainUI.text += $"\n- Block one path";
        if (effect.produce)
            textExplainUI.text += $"\n- Produce supplies";
        if (effect.loot)
            textExplainUI.text += $"\n- Bring loot on return";
    }
    void Update()
    {
        UpdatePlayable();
        UpdateForbidenToPlay();
    }
    void UpdatePlayable()
    {
        if(gameObject.GetComponentInParent<Event>().Defending() && response.CurrentVigilantCanPay())
            playable.SetActive(true);
        else if (!gameObject.GetComponentInParent<Event>().Defending() && response.CurrentEngagedCanPay())
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
    public void ActivateExplainingWindow()
    {
        if (effect.loss)
        {
            loss.SetActive(true);
            return;
        }
            
        if (effect.win)
        {
            win.SetActive(true);
            return;
        }

        textExplainUI.gameObject.SetActive(true);
       
    }
    public void DeactivateExplainingWindow()
    {
        win.SetActive(false);
        loss.SetActive(false);
        textExplainUI.gameObject.SetActive(false);
    }
}
