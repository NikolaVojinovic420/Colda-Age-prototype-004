using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventResponse : MonoBehaviour
{
    public EventStage eventStage;
    public UnitDisplay unitDisplay;
    public GameObject aspectObject;
    public GameObject effectObject;
    public GameObject greenLight;
    public StateMachine stateMachine;

    // Start is called before the first frame update
    void Awake()
    {
        eventStage = GameObject.FindWithTag("EventStage").GetComponent<EventStage>();
        unitDisplay = GameObject.FindWithTag("UnitDisplay").GetComponent<UnitDisplay>();
        stateMachine = GameObject.FindWithTag("StateMachine").GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Aplicable())
            greenLight.SetActive(true);
        else greenLight.SetActive(false);
    }
    bool Aplicable() => unitDisplay.sumEngagedObject.GetComponent<Aspect>().CanPay(aspectObject.GetComponent<Aspect>());
    void RespondToEvent()
    {
        Debug.Log($"{Time.time} Hit on {gameObject.name} {gameObject.transform.parent.gameObject.name}");
        if (Aplicable())
            stateMachine.OnResponse(this);      
    }
    public void OnMouseDown() => RespondToEvent();
}
