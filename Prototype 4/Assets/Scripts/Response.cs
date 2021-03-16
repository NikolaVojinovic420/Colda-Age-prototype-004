using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Response : MonoBehaviour
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
        stateMachine.ResponseClicked(this);
    }
}