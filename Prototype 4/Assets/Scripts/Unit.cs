using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Aspect aspect;
    public UnitDisplay unitDisplay;
    // Start is called before the first frame update
    void Start()
    {
        unitDisplay = GameObject.FindWithTag("UnitDisplay").GetComponent<UnitDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() => EngageDisengage();
    void EngageDisengage()
    {
        if (gameObject.transform.parent == unitDisplay.vigilant && unitDisplay.orchestrator.canEngageDisengage)
            gameObject.transform.SetParent(unitDisplay.engaged.transform);
        else if(gameObject.transform.parent == unitDisplay.engaged && unitDisplay.orchestrator.canEngageDisengage)
            gameObject.transform.SetParent(unitDisplay.vigilant.transform);
    }
}
