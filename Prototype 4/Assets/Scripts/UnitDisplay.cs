using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitDisplay : MonoBehaviour
{
    //TODO make private
    public Unit[] units = new Unit[10];

    public bool IsFull()
    {
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i] == null)
                return false;
        }
        return true;
    }

    public bool Contains(Unit u)
    {
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i] == u)
                return true;
        }
        return false;
    }

    public void Add(Unit u)
    {
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i] == null)
            {
                Add(u, i);
                break;
            }
        }
    }
    public void Add(Unit u, int index)
    {
        units[index] = u;
        u.Transfer(transform, CalcPosition(index), true);
    }

    public void TransferUnit(UnitDisplay newDisplay, Unit unitToTransfer)
    {
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i] == unitToTransfer)
            {
                newDisplay.Add(units[i], i);
                units[i] = null;
                break;
            }
        }
    }

    public void Reorder()
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
                units[freeSlotIndex].Transfer(transform, CalcPosition(freeSlotIndex), true);
                units[i] = null;
                i = freeSlotIndex;
                freeSlotIndex = -1;
            }
        }
    }

    private Vector3 CalcPosition(int index)
    {
        Vector3 parentPos = gameObject.transform.position;
        Vector3 pos = new Vector3(parentPos.x + index * 4.2f, parentPos.y, parentPos.z);
        return pos;
    }

    public AspectMap CalcAspectSum()
    {
        AspectMap am = new AspectMap();
        for (int i = 0; i < units.Length; i++)
            if (units[i] != null && units[i].IsActive())
                units[i].AddAspectTo(am);
        return am;
    }
}
