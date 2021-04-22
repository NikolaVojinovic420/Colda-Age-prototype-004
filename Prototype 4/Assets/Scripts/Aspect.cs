using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspect : MonoBehaviour
{
    public int a, p, l;

    public int GetAggression() { return a; }
    public void AddAgression(int amount) => a += amount;
    public int GetPractical() { return p; }
    public void AddPractical(int amount) => p += amount;
    public int GetLeader() { return l; }
    public void AddLeadership(int amount) => l += amount;
    public string ReturnAspectString() => $"\nA  {a}\nP  {p}\nL  {l}";
}
