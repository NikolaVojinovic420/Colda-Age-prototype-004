using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orchestrator : MonoBehaviour
{
    public GameObject eventStageObject;
    public EventStage eventStage;
    public GameObject unitDisplayObject;
    public UnitDisplay unitDisplay;
    public Drawer drawer;

    //block
    bool drawEventFree = false;
    public bool canEngageDisengage = true;
    bool responded = false;
    bool canMigrateEngaged = false;
    bool askForReshuffle = false;
    bool canDraw = false;
    int drawTimes = 0;
    // Start is called before the first frame update
    void Start()
    {
        drawer = gameObject.GetComponent<Drawer>();
        eventStage = eventStageObject.GetComponent<EventStage>();
        unitDisplay = unitDisplayObject.GetComponent<UnitDisplay>();
        DrawEvent();
        for (int i = 0; i < 5; i++)
            drawer.DrawFirst(unitDisplay.preparing, unitDisplay.vigilant);
    }

    void FixedUpdate()
    {
        Controller();
    }
    void DrawEvent()
    {
        if (eventStage.activeEventStage.transform.childCount <= 0)
            drawer.DrawFirst(eventStage.future, eventStage.activeEventStage);
    }
    void Controller()
    {
        //draw event
        if (Input.GetKeyDown("F1") && drawEventFree)
        {
            DrawEvent();
            Debug.Log($"{Time.time} Orchestrator drawed an event");
        }
        //unit engage and disengage
        if(Input.GetKeyDown("F2") && !canEngageDisengage)
        {
            Debug.Log("Orchestrator aproves Engage/Disengage method");
            canEngageDisengage = true;
            responded = true;
        }

        //Responding to event
        if (Input.GetKeyDown("F3") && responded)
        {
            Debug.Log($"{Time.time} Orchestrator accept respond and continues, u can migrate Engaged");
            canMigrateEngaged = true;
            responded = false;
        }
        //send engaged into recovering
        if (Input.GetKeyDown("F4") && canMigrateEngaged)
        {
            Debug.Log($"{Time.time} Orchestrator moving migrating Engaged and ask for reshuffle");
            drawer.MigrateCards(unitDisplay.engaged, unitDisplay.recovering);
            canMigrateEngaged = false;
            askForReshuffle = true;
        }
        //controll reshuffle
        if (Input.GetKeyDown("F5") && askForReshuffle)
        {
            Debug.Log($"{Time.time} Orchestrator checking for reshuffle");
            ReshuffleFutureAndPreparingIfEmpty();
            askForReshuffle = false;
            canDraw = true;
        }
        //draw
        if (Input.GetKeyDown("F6") && canDraw)
        {
            Debug.Log($"{Time.time} Orchestrator draws {drawTimes} Units");
            for (int i = 0; i < drawTimes; i++)
                    drawer.DrawFirst(unitDisplay.preparing, unitDisplay.vigilant);
            canDraw = false;
            drawEventFree = true;
        }

    }
    public void CallOrchestrator(Effect effect)
    {
        Debug.Log($"{Time.time} Orchestrator got information that has been responded to event");
        responded = true;
        canEngageDisengage = false;
        drawTimes = effect.draw;
    }
    void ReshuffleFutureAndPreparingIfEmpty()
    {
        if(unitDisplay.preparing.transform.childCount <= 0)
        {
            Debug.Log($"{Time.time} Orchestrator reshuffling into preparing from recovering");
            drawer.MigrateCards(unitDisplay.recovering, unitDisplay.preparing);
            drawer.Reshuffle(unitDisplay.preparing);
        }
        if(eventStage.future.transform.childCount <= 0)
        {
            Debug.Log($"{Time.time} Orchestrator reshuffling into future from history");
            drawer.MigrateCards(eventStage.history, eventStage.future);
            drawer.Reshuffle(eventStage.future);
        }
    }
}
