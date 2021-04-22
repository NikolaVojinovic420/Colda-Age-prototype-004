using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Supplies : MonoBehaviour
{
    [SerializeField]
    int value;
    [SerializeField]
    int sendIndexA, sendIndexP, sendIndexL, eatIndexA, produceIndexP, lootIndex;
    [SerializeField]
    public GameObject slider;
    Slider exploreLevel;

    void Awake()
    {
        exploreLevel = slider.GetComponent<Slider>();
    }

    public int GetValue() => value;
    public bool CheckSuppliesForSend(Aspect a)  
    {
        int amount = a.a * sendIndexA + a.p * sendIndexP + a.l * sendIndexL;
        if (value - amount < 0)
            return false;
        return true;
    }
    public void SendSupplies(Aspect a)
    {
        int amount = a.a* sendIndexA +a.p * sendIndexP + a.l * sendIndexL;
        value -= amount;
    }
    public void ProduceSupplies(Aspect a) => value += a.p * produceIndexP;
    public bool EatSupplies(Aspect a)
    {
        int amount = a.a * eatIndexA;

        if (value - amount < 0)
            return false;
           
        value -= amount;
        return true;
    }
    public void ReturnLoot() => value += Mathf.RoundToInt((exploreLevel.value * lootIndex) /100);
    public void SpendToTrain(int amount)//TODO
    {
        value -= amount;
        //upgrade aspect point for price
    }
}
