using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspect : MonoBehaviour
{
    public int a, p, c;

    public int GetAggression() { return a; }
    public int GetPractical() { return p; }
    public int GetCreative() { return c; }

    public string ReturnAspectString() => $"\nA = {a}\nP = {p}\nC = {c}";
}
