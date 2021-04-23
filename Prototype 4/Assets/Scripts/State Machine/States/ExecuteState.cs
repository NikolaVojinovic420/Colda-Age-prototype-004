﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteState : State
{
    private readonly Response eventResponse;
    private readonly Effect effect;

    public ExecuteState(StateMachine stateMachine, Response eResponse) : base(stateMachine)
    {
        eventResponse = eResponse;
        effect = eventResponse.GetComponent<Effect>();
    }

    public override IEnumerator Start()
    {
        if (effect.loss) //loss
        {
            _stateMachine.SetState(new LossState(_stateMachine));
            yield break;
        }

        if (effect.win) //win
        {
            _stateMachine.SetState(new WinState(_stateMachine));
            yield break;
        }

        if (effect.produce) //produce supplies
            _stateMachine.supplies.ProduceSupplies(_stateMachine.vigilantAspectsDisplay._aspect);

        if (effect.loot) //brings loot
            for (int i = 0; i < _stateMachine.engaged.units.Length; i++)
                _stateMachine.engaged.units[i].bringsLoot = true;

                if (effect.insertEvent != null) //insert new event into history
        {
            // FIXME: unique events are copied, and should not be
            if (!_stateMachine.history.Contains(effect.insertEvent.name) && !_stateMachine.future.Contains(effect.insertEvent.name))
            {      
                GameObject eventObject = UnityEngine.Object.Instantiate(effect.insertEvent, _stateMachine.history.transform);
                Event e = eventObject.GetComponent<Event>();

                eventObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                eventObject.transform.position = _stateMachine.eventStageObject.transform.position;

                Event newEvent = eventObject.GetComponent<Event>();
                _stateMachine.history.AddEvent(newEvent);
            }
            else
            {
                Debug.Log("inserted event in response already exists in history or future");
            }
        }

        _stateMachine.supplies.SendSupplies(_stateMachine.engagedAspectsDisplay._aspect); //send supplies with engaged units

        _stateMachine.IncreaseExploration(_stateMachine.engagedAspectsDisplay._aspect);  //increase exploration
        //block/exhaust event
        {
            if(effect.exhaustEvent != null)
            {
                if(_stateMachine.future.Contains(effect.exhaustEvent.name))
                {
                    Event e = _stateMachine.future.RemoveWhereName(effect.exhaustEvent.name);
                    e.gameObject.GetComponent<Animate>().DisolveCard();
                    Object.Destroy(e.gameObject);
                }
            }
        }

        //upgrades
        if(effect.upgradeSend) //upgrade spending for send
            _stateMachine.supplies.UpgradeSendIndex();

        if(effect.upgradeProduce) //upgrade produce
            _stateMachine.supplies.UpgradeProductionIndex();

        if (effect.upgradeEat) //upgrade eat at reshuffling
            _stateMachine.supplies.UpgradeEatIndex();

        if (effect.upgradeUnitA && _stateMachine.engaged.transform.childCount == 1) //upgrade unit aggression
            _stateMachine.supplies.UpgradeAggression(_stateMachine.engaged.transform.GetChild(0).gameObject);

        if (effect.upgradeUnitP && _stateMachine.engaged.transform.childCount == 1) //upgrade unit aggression
            _stateMachine.supplies.UpgradePractical(_stateMachine.engaged.transform.GetChild(0).gameObject);

        if (effect.upgradeUnitL && _stateMachine.engaged.transform.childCount == 1) //upgrade unit aggression
            _stateMachine.supplies.UpgradeLeadership(_stateMachine.engaged.transform.GetChild(0).gameObject);

        Event currentEvent = eventResponse.gameObject.transform.parent.gameObject.GetComponent<Event>();
        //exhaust or discard event
        if (effect.exhaustable)
        {
            currentEvent.gameObject.GetComponent<Animate>().DisolveCard();
            UnityEngine.Object.Destroy(currentEvent.gameObject);
        }    
        else
        {
            currentEvent.Transfer(_stateMachine.history.transform, false);
            _stateMachine.history.AddEvent(currentEvent);
        }

        //move all units from engaged back to vigilant
        for (int i = 0; i < _stateMachine.engaged.units.Length; i++)
        {
            Unit u = _stateMachine.engaged.units[i];
            if (u == null)
                continue;
            u.Fatique(_stateMachine.ReturningDistance());
            u.gameObject.GetComponent<AudioController>().PlayFlip();
            _stateMachine.engaged.TransferUnit(_stateMachine.vigilant, u);
        }

        _stateMachine.engagedAspectsDisplay.SetAspect(new AspectMap());
        _stateMachine.DisplaySupplies();

        _stateMachine.vigilant.Reorder();
        _stateMachine.SetState(new DrawEventState(_stateMachine));
        yield break;
    }
}
