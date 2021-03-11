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
        txtMeshObject.text = gameObject.name.Split('(')[0];

        if (gameObject.tag == "Unit")
            txtMeshObject.text += gameObject.GetComponent<Unit>().aspect.ReturnAspectString();

        if (gameObject.tag == "Response")
        {
            txtMeshObject.text += GetComponent<Aspect>().ReturnAspectString(); // req

            if (GetComponent<Effect>().win) //win
            {
                txtMeshObject.text += $"\nWin!";
                return;
            }
                
            if (GetComponent<Effect>().loss) // loss
            {
                txtMeshObject.text += $"\nLoss!";
                return;
            }

            if (GetComponent<Effect>().draw > 0) // draw
                txtMeshObject.text += $"\nDraw {GetComponent<Effect>().draw > 0}";

            if (GetComponent<Effect>().insertEvent != null)
                txtMeshObject.text += $"\nInsert {GetComponent<Effect>().insertEvent.name}";

            if (GetComponent<Effect>().exhaustable) //exhaust
                txtMeshObject.text += "\nExhaust";
        }
    }
}
