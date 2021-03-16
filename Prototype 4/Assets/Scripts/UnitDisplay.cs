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
        u.setPosition(calcPosition(index));
    }

    public void transferUnit(UnitDisplay newDisplay, Unit unitToTransfer)
    {
        Debug.Log("Transfering unit="+unitToTransfer+" from "+this+" to "+newDisplay);
        for (int i = 0; i < units.Length; i++)
        {
            Debug.Log("index="+i+" -> "+units[i]);
            if (units[i] == unitToTransfer)
            {
                Debug.Log("unit found at index="+i);
                units[i].Move(newDisplay.gameObject);
                newDisplay.add(units[i], i);
                units[i] = null;
                break;
            }
            Debug.Log("unit was NOT found at index=" + i);
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

    public Vector3 calcPosition(int index)
    {
        Vector3 parentPos = gameObject.transform.position;
        Vector3 pos = new Vector3(parentPos.x + index * 2.5f, parentPos.y, parentPos.z);
        return pos;
    }
}
