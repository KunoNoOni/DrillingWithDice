using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceTray : AllMyChildren
{
    public GameObject[] dice;

    public void RandomizeDiceTray(bool reroll)
    {
        Transform[] diceTraySlots = GetComponentsInChildren<Transform>();

        foreach (Transform diceTraySlot in diceTraySlots)
        {
            if (!reroll && diceTraySlot.CompareTag("SlotDiceTray") && !HasChild(diceTraySlot))
            {
                RollDice(diceTraySlot);
            }
            else if (diceTraySlot.CompareTag("SlotDiceTray") && HasChild(diceTraySlot))
            {
                RollDice(diceTraySlot);
            }
        }
    }

    private void RollDice(Transform diceTraySlot)
    {
        GameObject die = GetRandomDie();
        GameObject go = Instantiate(die);
        go.transform.SetParent(diceTraySlot);
        go.transform.position = diceTraySlot.position;
        go.GetComponent<RotateDice>().SetCanRotate(true);
    }

    public GameObject GetRandomDie()
    {
        int randomNumber = Random.Range(0, 6);
        return dice[randomNumber];
    }

    public override void DestroyAllChildren()
    {
        Transform[] diceTraySlots = GetComponentsInChildren<Transform>();
        foreach (Transform diceTraySlot in diceTraySlots)
        {
            if (diceTraySlot.CompareTag("SlotDiceTray") && HasChild(diceTraySlot))
            {
                DestroyChild(diceTraySlot);
            }
        }
    }

    public override bool CheckForDie()
    {
        throw new System.NotImplementedException();
    }
}
