using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspect : MonoBehaviour
{
    [SerializeField]
    private int a, p, c;

    public bool ApplicableTo(Aspect cost)
    {
        return a >= cost.a && p >= cost.p && c >= cost.c;
    }

    public void Add(Aspect addFrom)
    {
        a += addFrom.a;
        p += addFrom.p;
        c += addFrom.c;
    }

    public string ReturnAspectString() => $"\nA = {a}\nP = {p}\nC = {c}";
}
