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
        if (gameObject.tag == "Unit")
            txtMeshObject.text = gameObject.name.Split('(')[0] +
                 $"\nA={gameObject.GetComponent<Unit>().aspectObject.GetComponent<Aspect>().a}" +
                 $"\nP={gameObject.GetComponent<Unit>().aspectObject.GetComponent<Aspect>().p}" +
                 $"\nC={gameObject.GetComponent<Unit>().aspectObject.GetComponent<Aspect>().c}";
        else txtMeshObject.text = gameObject.name.Split('(')[0];
    }
}
