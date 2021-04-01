using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UpdateEventUI : MonoBehaviour
{
    public TMP_Text nameUI;
    void Awake()
    {
        nameUI.text = gameObject.name.Split('(')[0];
    }

}
