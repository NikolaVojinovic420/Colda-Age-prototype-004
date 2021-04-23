using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Effect : MonoBehaviour
{
    public bool stopMakingInstances;

    public bool win;
    public bool loss;
    public bool exhaustable;
    public GameObject insertEvent;

    public GameObject exhaustEvent;
    public bool produce;
    public bool loot;

    public bool upgradeSend;
    public bool upgradeProduce;
    public bool upgradeEat;
    public bool upgradeUnitA;
    public bool upgradeUnitP;
    public bool upgradeUnitL;
    public string SetOneUpgradeText()
    {
        if(upgradeSend)
            return "- Upgrade sending index";
        if (upgradeProduce)
            return "- Upgrade produce index";
        if (upgradeEat)
            return "- Upgrade spend index";
        if (upgradeUnitA)
            return "- Upgrade aggression";
        if (upgradeUnitP)
            return "- Upgrade practical";
        if (upgradeUnitL)
            return "- Upgrade leadership";
        return "";
    }
}
