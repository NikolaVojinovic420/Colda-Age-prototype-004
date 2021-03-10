using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventResponse : MonoBehaviour
{
    public GameObject greenLight;
    public StateMachine stateMachine;

    // Start is called before the first frame update
    void Awake()
    {
        stateMachine = FindObjectOfType<StateMachine>();
    }

    void RespondToEvent() => stateMachine.OnResponse(this); 
    public void OnMouseDown() => RespondToEvent();
}
