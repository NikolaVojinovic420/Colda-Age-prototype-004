using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectMap
{
    private int aggression;
    private int practical;
    private int creative;

    public bool ApplicableTo(Aspect cost)
    {
        return aggression >= cost.GetAggression() &&
            practical >= cost.GetPractical() &&
            creative >= cost.GetCreative();
    }

    public void Add(Aspect addFrom)
    {
        aggression += addFrom.GetAggression();
        practical += addFrom.GetPractical();
        creative += addFrom.GetCreative();
    }

    public void MirrorValuesTo(Aspect reflection)
    {
        reflection.a = aggression;
        reflection.p = practical;
        reflection.c = creative;
    }
}
