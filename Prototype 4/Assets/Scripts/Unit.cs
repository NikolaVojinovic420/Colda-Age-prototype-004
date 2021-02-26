using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public GameObject aspectObject;
    public Aspect aspect;
    public UnitDisplay unitDisplay;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        aspect = aspectObject.GetComponent<Aspect>();
        unitDisplay = GameObject.FindWithTag("UnitDisplay").GetComponent<UnitDisplay>();
        txt.text = $"{gameObject.name}\n{aspect.ReturnAspectString()}";
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
