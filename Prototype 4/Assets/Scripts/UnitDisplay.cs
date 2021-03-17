using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitDisplay : MonoBehaviour
{
    //TODO make private
    public Unit[] units = new Unit[10];

    public void add(Unit u)
    {
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i] == null)
            {
                add(u, i);
                break;
            }
        }
    }
    public void add(Unit u, int index)
    {
        units[index] = u;
        //u.setPosition(calcPosition(index));
    }

    public void transferUnit(UnitDisplay newDisplay, Unit unitToTransfer)
    {
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i] == unitToTransfer)
            {
                units[i].Move(newDisplay.gameObject);
                newDisplay.add(units[i], i);
                units[i] = null;
                break;
            }
        }
    }

    public void reorder()
    {
        int freeSlotIndex = -1;
        for (int i = 0; i < units.Length; i++)
        {
            if (freeSlotIndex == -1 && units[i] == null)
            {
                freeSlotIndex = i;
                continue;
            }
            if (freeSlotIndex > -1 && units[i] != null)
            {
                units[freeSlotIndex] = units[i];
                units[freeSlotIndex].setPosition(calcPosition(freeSlotIndex));
                units[i] = null;
                freeSlotIndex = i;
            }
        }
    }

    private Vector3 calcPosition(int index)
    {
        Vector3 parentPos = gameObject.transform.position;
        Vector3 pos = new Vector3(parentPos.x + index * 2.5f, parentPos.y, parentPos.z);
        return pos;
    }

    public Aspect calcAspectSum()
    {
        Aspect a = new Aspect();
        for (int i = 0; i < units.Length; i++)
            if (units[i] != null)
                a.add(units[i].aspect);
        return a;
    }
}
