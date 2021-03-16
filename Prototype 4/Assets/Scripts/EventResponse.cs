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

    public void OnMouseDown()
    {
        Debug.Log("response clicked");
        stateMachine.OnResponse(this);
    }
}
