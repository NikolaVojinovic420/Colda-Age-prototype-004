using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspect : MonoBehaviour
{
    public int a, p, c;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool CanPay(Aspect asp) => (a >= asp.a && p >= asp.p && c >= asp.c);

    public void Copy(GameObject deck) // this reset aspect
    {
        a = 0;
        p = 0;
        c = 0;
        for (int i = 0; i < deck.transform.childCount; i++)
        {
              if (deck.transform.GetChild(i).gameObject.GetComponent<Unit>().aspect != null)
              {
                a += deck.transform.GetChild(i).gameObject.GetComponent<Unit>().aspect.a;
                p += deck.transform.GetChild(i).gameObject.GetComponent<Unit>().aspect.p;
                c += deck.transform.GetChild(i).gameObject.GetComponent<Unit>().aspect.c;
              }
        }
    }
    public string ReturnAspectString() => $"A = {a}\nP = {p}\nC = {c}";

}
