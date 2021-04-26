using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllMyChildren : MonoBehaviour
{
    public abstract void DestroyAllChildren();

    public abstract bool CheckForDie();

    public void DestroyChild(Transform diceTraySlot)
    {
        GameObject badChild = diceTraySlot.GetChild(0).gameObject;
        Destroy(badChild);
    }

    public bool HasChild(Transform diceTraySlot)
    {
        return diceTraySlot.childCount > 0;
    }

}
