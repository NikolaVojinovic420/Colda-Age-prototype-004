using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventResponse : MonoBehaviour
{
    public EventStage eventStage;
    public UnitDisplay unitDisplay;
    public GameObject aspectObject;
    public Aspect reqAspect;
    public GameObject effectObject;
    public Effect effect;

    // Start is called before the first frame update
    void Start()
    {
        eventStage = GameObject.FindWithTag("EventStage").GetComponent<EventStage>();
        unitDisplay = GameObject.FindWithTag("UnitDisplay").GetComponent<UnitDisplay>();
        reqAspect = aspectObject.GetComponent<Aspect>();
        effect = effectObject.GetComponent<Effect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool Aplicable() => unitDisplay.sumEngaged.CanPay(reqAspect);
    void RespondToEvent()
    {
        if (Aplicable())
            eventStage.ExecuteEndEvent(effect);
    }
    public void OnMouseDown() => RespondToEvent();
}
