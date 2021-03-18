using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private Card card;
    public Vector3 moveDestination;
    // move animation
    [SerializeField]
    float moveSpeed;
    //rotation
    [SerializeField]
    float rotateSpeed;
    //poof
    public GameObject poofEffect;

    void Awake()
    {
        card = GetComponent<Card>();
        
    }
    private void Start()
    {
        Poof();
    }

    void Update()
    {
        Flip();
        MoveTo();
    }
    public void MoveTo() => transform.position = Vector3.MoveTowards(gameObject.transform.position, moveDestination, moveSpeed * Time.deltaTime);
    public void Flip()
    {
        if(card.IsActive())
            transform.rotation = Quaternion.RotateTowards(transform.rotation.normalized, Quaternion.Euler(0, 0, 0).normalized, rotateSpeed * Time.deltaTime);
        else 
            transform.rotation = Quaternion.RotateTowards(transform.rotation.normalized, Quaternion.Euler(0, 180, 0f).normalized, rotateSpeed * Time.deltaTime);
    }
    public void Poof() => Instantiate(poofEffect, gameObject.transform);
    
    public void Disapear()
    {

    }
}
