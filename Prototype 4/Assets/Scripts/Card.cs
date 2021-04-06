using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    protected Animate animator;

    private string cardName;
    public string GetCardName() { return cardName; }

    private bool Active;
    public virtual bool IsActive() { return Active; }
    public void SetActive(bool active) { Active = active; }
    public void Transfer(Transform newParent, Vector3 position, bool active)
    {
        SetActive(active);
        gameObject.transform.SetParent(newParent);
        animator.moveDestination = position;
    }
    public void Transfer(Transform newParent, bool active)
    {
        Vector3 position = newParent.position;
        Transfer(newParent, position, active);
    }
}
