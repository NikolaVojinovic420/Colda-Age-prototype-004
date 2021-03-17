using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectDisplay : MonoBehaviour
{
    public Aspect _aspect;
    void Awake()
    {
        _aspect = GetComponent<Aspect>();
    }
    void UpdateUIAspect() => GetComponent<Text>().text = _aspect.ReturnAspectString();
    public void SetAspect(AspectMap aspectMap)
    {
        aspectMap.MirrorValuesTo(_aspect);
        UpdateUIAspect();
    }
}
