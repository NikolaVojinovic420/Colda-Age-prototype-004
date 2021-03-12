using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Aspect aspect;
    public bool isEngaged = false;
    StateMachine stateMachine;
    void Awake()
    {
        stateMachine = FindObjectOfType<StateMachine>();
        aspect = GetComponent<Aspect>();
    }
    void OnMouseDown()
    {
        isEngaged = !isEngaged;
        if (isEngaged)
            stateMachine.Engage(this);
        else stateMachine.Disengage(this);
    }
    public void Move(GameObject destination)
    {
        gameObject.transform.SetParent(destination.transform);
        GetComponent<Animate>().moveDestination = destination;
    }
}
