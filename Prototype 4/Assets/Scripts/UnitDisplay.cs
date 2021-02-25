using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitDisplay : MonoBehaviour
{
    public GameObject sumVigilantObject;
    public Aspect sumVigilant;
    public GameObject sumEngagedObject;
    public Aspect sumEngaged;
    public GameObject preparing;
    public GameObject recovering;
    public GameObject vigilant;
    public GameObject engaged;
    public GameObject vigAspectUIObject;
    public GameObject engAspectUIObject;
    public GameObject orchestratorObject;
    public Orchestrator orchestrator;

    int vigCount = 0;
    int engCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        orchestrator = orchestratorObject.GetComponent<Orchestrator>();
        sumVigilant = sumEngagedObject.GetComponent<Aspect>();
        sumEngaged = sumEngagedObject.GetComponent<Aspect>();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshAspects();
    }
    public void CopyAspects()
    {
        for (int i = 0; i < vigilant.transform.childCount; i++)
            sumVigilant.Copy(vigilant);
        for (int i = 0; i < engaged.transform.childCount; i++)
            sumEngaged.Copy(engaged);
    }
    void RefreshAspects()
    {
        if (vigCount != vigilant.transform.childCount || engCount != engaged.transform.childCount)
        {
            CopyAspects();
            UpdateAspectsUI();
        }          
    }
    void UpdateAspectsUI()
    {
        vigAspectUIObject.GetComponent<Text>().text = $"Vigilant:\n{sumVigilant.ReturnAspectString()}";
        engAspectUIObject.GetComponent<Text>().text = $"Engaged:\n{sumEngaged.ReturnAspectString()}";
    }
}
