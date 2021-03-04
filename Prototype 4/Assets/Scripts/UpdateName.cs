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
            txtMeshObject.text += gameObject.GetComponent<Unit>().aspectObject.GetComponent<Aspect>().ReturnAspectString();

        if (gameObject.tag == "Response")
        {
            txtMeshObject.text += gameObject.GetComponent<EventResponse>().aspectObject.GetComponent<Aspect>().ReturnAspectString(); // req

            if (gameObject.GetComponent<EventResponse>().effectObject.GetComponent<Effect>().win) //win
            {
                txtMeshObject.text += $"\nWin!";
                return;
            }
                
            if (gameObject.GetComponent<EventResponse>().effectObject.GetComponent<Effect>().loss) // loss
            {
                txtMeshObject.text += $"\nLoss!";
                return;
            }

            if (gameObject.GetComponent<EventResponse>().effectObject.GetComponent<Effect>().draw > 0) // draw
                txtMeshObject.text += $"\nDraw {gameObject.GetComponent<EventResponse>().effectObject.GetComponent<Effect>().draw}";

            if (gameObject.GetComponent<EventResponse>().effectObject.GetComponent<Effect>().insertEvent != null)
                txtMeshObject.text += $"\nInsert {gameObject.GetComponent<EventResponse>().effectObject.GetComponent<Effect>().insertEvent.name}";

            if (gameObject.GetComponent<EventResponse>().effectObject.GetComponent<Effect>().exhaustable) //exhaust
                txtMeshObject.text += "\nExhaust";
        }
    }
}
