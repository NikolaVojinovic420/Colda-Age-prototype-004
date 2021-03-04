using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public GameObject aspectObject;
    public Aspect aspect;
    public UnitDisplay unitDisplay;
    // Start is called before the first frame update
    void Start()
    {
        aspect = aspectObject.GetComponent<Aspect>();
        unitDisplay = GameObject.FindWithTag("UnitDisplay").GetComponent<UnitDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown() => EngageDisengage();
    void EngageDisengage()
    {
        if(!Engage())
            Disengage();   
    }
    bool Engage()
    {       
        if (gameObject.transform.parent.tag == "Vigilant" && unitDisplay.orchestrator.canEngageDisengage)
        {
            gameObject.transform.position = unitDisplay.engaged.transform.position;
            gameObject.transform.SetParent(unitDisplay.engaged.transform);
            Debug.Log($"{Time.time} {gameObject.name} engaged");
            return true;
        }
        return false;
    }
    void Disengage()
    {
        if (unitDisplay.orchestrator.canEngageDisengage)
        {
            gameObject.transform.position = unitDisplay.vigilant.transform.position;
            gameObject.transform.SetParent(unitDisplay.vigilant.transform);
            Debug.Log($"{Time.time} {gameObject.name} disengaged");
        }
    }
}
