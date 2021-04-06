using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspect : MonoBehaviour
{
    public int a, p, l;

    public int GetAggression() { return a; }
    public int GetPractical() { return p; }
    public int GetLeader() { return l; }

    public string ReturnAspectString() => $"\nA = {a}\nP = {p}\nC = {l}";
}
