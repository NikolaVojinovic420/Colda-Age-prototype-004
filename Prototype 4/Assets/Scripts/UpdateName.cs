using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateName : MonoBehaviour
{
    public TMP_Text txtMeshObject;
    // Start is called before the first frame update
    void Start()
    {
        txtMeshObject.text = gameObject.name;
    }
}
