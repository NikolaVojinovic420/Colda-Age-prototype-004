using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Unit : MonoBehaviour
{
    public GameObject aspectObject;
    public Aspect aspect;
    public UnitDisplay unitDisplay;
    public TMP_Text meshObject;
    // Start is called before the first frame update
    void Start()
    {
        aspect = aspectObject.GetComponent<Aspect>();
        unitDisplay = GameObject.FindWithTag("UnitDisplay").GetComponent<UnitDisplay>();
        meshObject.text = $"{gameObject.name}\n{aspect.ReturnAspectString()}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown() => EngageDisengage();
    void EngageDisengage()
    {
        Debug.Log($"{Time.time} Hit {gameObject.name} in {gameObject.transform.parent.name}");
        if (gameObject.transform.parent.tag == "Vigilant" && unitDisplay.orchestrator.canEngageDisengage)
        {
            gameObject.transform.position = unitDisplay.engaged.transform.position;
            gameObject.transform.SetParent(unitDisplay.engaged.transform);
        }
        else if (gameObject.transform.parent.tag == "Engaged" && unitDisplay.orchestrator.canEngageDisengage)
        {
            gameObject.transform.position = unitDisplay.vigilant.transform.position;
            gameObject.transform.SetParent(unitDisplay.vigilant.transform);
        }
    }
}
