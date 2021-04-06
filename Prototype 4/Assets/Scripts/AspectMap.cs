using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectMap
{
    private int aggression;
    private int practical;
    private int leadership;

    public bool ApplicableTo(Aspect cost)
    {
        return aggression >= cost.GetAggression() &&
            practical >= cost.GetPractical() &&
            leadership >= cost.GetLeader();
    }

    public void Add(Aspect addFrom)
    {
        aggression += addFrom.GetAggression();
        practical += addFrom.GetPractical();
        if(leadership < addFrom.GetLeader())
            leadership = addFrom.GetLeader();
    }

    public void MirrorValuesTo(Aspect reflection)
    {
        reflection.a = aggression;
        reflection.p = practical;
        reflection.l = leadership;
    }
}
