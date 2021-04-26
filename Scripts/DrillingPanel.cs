using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrillingPanel : MonoBehaviour
{
    private Image diceBox1;
    private Image diceBox2;
    private Image diceBox3;
    private Image diceBox4;
    private Image diceBox5;
    private Image diceBox6;
    private Button resultButton;

    private void Start()
    {
        Image[] diceTraySlots = GetComponentsInChildren<Image>();
        diceBox1 = diceTraySlots[1];
        diceBox2 = diceTraySlots[2];
        diceBox3 = diceTraySlots[3];
        diceBox4 = diceTraySlots[4];
        diceBox5 = diceTraySlots[5];
        diceBox6 = diceTraySlots[6];
        resultButton = FindObjectOfType<RollResultDieButton>().GetComponentInChildren<Button>();
    }

    public string GetDieInSlot(string slot)
    {
        string tag = "";

        switch(slot)
        {
            case "slot1":
                if (diceBox1.GetComponentInChildren<DragHandler>())
                {
                    tag = diceBox1.GetComponentInChildren<DragHandler>().gameObject.tag;
                }
                break;
            case "slot3":
                if (diceBox3.GetComponentInChildren<DragHandler>())
                {
                    tag = diceBox3.GetComponentInChildren<DragHandler>().gameObject.tag;
                }
                break;
            case "slot5":
                if (diceBox5.GetComponentInChildren<DragHandler>())
                {
                    tag = diceBox5.GetComponentInChildren<DragHandler>().gameObject.tag;
                }
                break;
        }

        return tag;
    }

    public void EnableDisableDiceBoxes()
    {

        //Debug.Log("diceBox3's color is" + diceBox3.color.ToString());
        //if (diceBox1.GetComponentInChildren<DragHandler>())
        //    Debug.Log("diceBox1 has a child!");
        //if (diceBox2.GetComponentInChildren<DragHandler>())
        //    Debug.Log("diceBox2 has a child!");
        //if (diceBox3.GetComponentInChildren<DragHandler>())
        //    Debug.Log("diceBox3 has a child!");
        //if (diceBox4.GetComponentInChildren<DragHandler>())
        //    Debug.Log("diceBox4 has a child!");
        //if (diceBox5.GetComponentInChildren<DragHandler>())
        //    Debug.Log("diceBox5 has a child!");
        //if (diceBox6.GetComponentInChildren<DragHandler>())
        //    Debug.Log("diceBox6 has a child!");
        if (diceBox1.GetComponentInChildren<DragHandler>() && diceBox2.GetComponentInChildren<DragHandler>() && diceBox3.color != Color.black)
        {
            diceBox3.color = new Color32(255, 255, 255, 255);
            diceBox3.raycastTarget = true;
            diceBox4.color = new Color32(255, 255, 255, 255);
            diceBox4.raycastTarget = true;
            resultButton.interactable = true;
        }
        else if (diceBox3.color != Color.black)
        {
            diceBox3.color = new Color32(255, 0, 0, 255);
            diceBox3.raycastTarget = false;
            diceBox4.color = new Color32(255, 0, 0, 255);
            diceBox4.raycastTarget = false;
            resultButton.interactable = false;
        }
        else
        {
            resultButton.interactable = true;
        }

        if (diceBox3.GetComponentInChildren<DragHandler>() && diceBox4.GetComponentInChildren<DragHandler>() && diceBox5.color != Color.black)
        {
            diceBox5.color = new Color32(255, 255, 255, 255);
            diceBox5.raycastTarget = true;
            diceBox6.color = new Color32(255, 255, 255, 255);
            diceBox6.raycastTarget = true;
        }
        else if (diceBox5.color != Color.black)
        {
            diceBox5.color = new Color32(255, 0, 0, 255);
            diceBox5.raycastTarget = false;
            diceBox6.color = new Color32(255, 0, 0, 255);
            diceBox6.raycastTarget = false;
        }
        else
        {
            resultButton.interactable = true;
        }
    }

    public void DisableDiceBoxesForProcessing()
    {
        diceBox1.color = new Color32(255, 0, 0, 255);
        diceBox1.raycastTarget = false;
        diceBox2.color = new Color32(255, 0, 0, 255);
        diceBox2.raycastTarget = false;
    }

    public void EnableDiceBoxesForProcessing()
    {
        diceBox1.color = new Color32(255, 255, 255, 255);
        diceBox1.raycastTarget = true;
        diceBox2.color = new Color32(255, 255, 255, 255);
        diceBox2.raycastTarget = true;
    }

    public void RemoveDice(string tag)
    {
        GameObject go;
        GameObject die;

        if (tag == "DrillingDiceTray1" || tag == "DrillingDiceTray2")
        {
            if (diceBox3.GetComponentInChildren<DragHandler>())
            {
                go = FreeSlotInDiceTray();

                if (go != null)
                {
                    die = diceBox3.GetComponentInChildren<DragHandler>().gameObject;
                    die.transform.SetParent(go.transform);
                    die.transform.position = go.transform.position;
                }
            }

            if (diceBox4.GetComponentInChildren<DragHandler>())
            {
                go = FreeSlotInDiceTray();

                if (go != null)
                {
                    die = diceBox4.GetComponentInChildren<DragHandler>().gameObject;
                    die.transform.SetParent(go.transform);
                    die.transform.position = go.transform.position;
                }
            }

            if (diceBox5.GetComponentInChildren<DragHandler>())
            {
                go = FreeSlotInDiceTray();

                if (go != null)
                {
                    die = diceBox5.GetComponentInChildren<DragHandler>().gameObject;
                    die.transform.SetParent(go.transform);
                    die.transform.position = go.transform.position;
                }
            }

            if (diceBox6.GetComponentInChildren<DragHandler>())
            {
                go = FreeSlotInDiceTray();

                if (go != null)
                {
                    die = diceBox6.GetComponentInChildren<DragHandler>().gameObject;
                    die.transform.SetParent(go.transform);
                    die.transform.position = go.transform.position;
                }
            }

        }

        if (tag == "DrillingDiceTray3" || tag == "DrillingDiceTray4")
        {
            if (diceBox5.GetComponentInChildren<DragHandler>())
            {
                go = FreeSlotInDiceTray();

                if (go != null)
                {
                    die = diceBox5.GetComponentInChildren<DragHandler>().gameObject;
                    die.transform.SetParent(go.transform);
                    die.transform.position = go.transform.position;
                }
            }

            if (diceBox6.GetComponentInChildren<DragHandler>())
            {
                go = FreeSlotInDiceTray();

                if (go != null)
                {
                    die = diceBox6.GetComponentInChildren<DragHandler>().gameObject;
                    die.transform.SetParent(go.transform);
                    die.transform.position = go.transform.position;
                }
            }
        }
    }

    private GameObject FreeSlotInDiceTray()
    {
        Transform[] diceTraySlots = FindObjectOfType<DiceTray>().GetComponentsInChildren<Transform>();
        GameObject go = null;


        foreach (Transform diceTraySlot in diceTraySlots)
        {
            if (diceTraySlot.name == "DiceSlot1" && diceTraySlot.childCount == 0)
            {
                go = diceTraySlot.gameObject;
            }
            if (diceTraySlot.name == "DiceSlot2" && diceTraySlot.childCount == 0)
            {
                go = diceTraySlot.gameObject;
            }
            if (diceTraySlot.name == "DiceSlot3" && diceTraySlot.childCount == 0)
            {
                go = diceTraySlot.gameObject;
            }
            if (diceTraySlot.name == "DiceSlot4" && diceTraySlot.childCount == 0)
            {
                go = diceTraySlot.gameObject;
            }
            if (diceTraySlot.name == "DiceSlot5" && diceTraySlot.childCount == 0)
            {
                go = diceTraySlot.gameObject;
            }
            if (diceTraySlot.name == "DiceSlot6" && diceTraySlot.childCount == 0)
            {
                go = diceTraySlot.gameObject;
            }
        }

        return go;
    }

    public int GetDepth()
    {
        int depth = 100;

        if (diceBox3.GetComponentInChildren<DragHandler>() && diceBox4.GetComponentInChildren<DragHandler>())
            depth = 200;
        if (diceBox5.GetComponentInChildren<DragHandler>() && diceBox6.GetComponentInChildren<DragHandler>())
            depth = 300;
        return depth;
    }

    public void DestroyAllChildren()
    {
        if (diceBox1.GetComponentInChildren<DragHandler>())
        {
            Debug.Log("The evil " + diceBox1.GetComponentInChildren<DragHandler>().gameObject.name + " hath been DESTROYED!");
            Destroy(diceBox1.GetComponentInChildren<DragHandler>().gameObject);
        }
        if (diceBox2.GetComponentInChildren<DragHandler>())
        {
            Debug.Log("The evil " + diceBox2.GetComponentInChildren<DragHandler>().gameObject.name + " hath been DESTROYED!");
            Destroy(diceBox2.GetComponentInChildren<DragHandler>().gameObject);
        }
        if (diceBox3.GetComponentInChildren<DragHandler>())
        {
            Debug.Log("The evil " + diceBox3.GetComponentInChildren<DragHandler>().gameObject.name + " hath been DESTROYED!");
            Destroy(diceBox3.GetComponentInChildren<DragHandler>().gameObject);
        }
        if (diceBox4.GetComponentInChildren<DragHandler>())
        {
            Debug.Log("The evil " + diceBox4.GetComponentInChildren<DragHandler>().gameObject.name + " hath been DESTROYED!");
            Destroy(diceBox4.GetComponentInChildren<DragHandler>().gameObject);
        }
        if (diceBox5.GetComponentInChildren<DragHandler>())
        {
            Debug.Log("The evil " + diceBox5.GetComponentInChildren<DragHandler>().gameObject.name + " hath been DESTROYED!");
            Destroy(diceBox5.GetComponentInChildren<DragHandler>().gameObject);
        }
        if (diceBox6.GetComponentInChildren<DragHandler>())
        {
            Debug.Log("The evil " + diceBox6.GetComponentInChildren<DragHandler>().gameObject.name + " hath been DESTROYED!");
            Destroy(diceBox6.GetComponentInChildren<DragHandler>().gameObject);
        }
    }

    public void DisableDepthBoxes(string depth)
    {
        if (depth == "200")
        {
            diceBox3.color = new Color32(0, 0, 0, 255);
            diceBox3.raycastTarget = false;
            diceBox4.color = new Color32(0, 0, 0, 255);
            diceBox4.raycastTarget = false;
            diceBox5.color = new Color32(0, 0, 0, 255);
            diceBox5.raycastTarget = false;
            diceBox6.color = new Color32(0, 0, 0, 255);
            diceBox6.raycastTarget = false;
        }
        else if (depth == "300")
        {
            diceBox5.color = new Color32(0, 0, 0, 255);
            diceBox5.raycastTarget = false;
            diceBox6.color = new Color32(0, 0, 0, 255);
            diceBox6.raycastTarget = false;
        }
    }

    public void EnableDepthBoxes(string depth)
    {
        if (depth == "200")
        {
            diceBox3.color = new Color32(255, 255, 255, 255);
            diceBox3.raycastTarget = true;
            diceBox4.color = new Color32(255, 255, 255, 255);
            diceBox4.raycastTarget = true;
        }
        else if (depth == "300")
        {
            diceBox3.color = new Color32(255, 255, 255, 255);
            diceBox3.raycastTarget = true;
            diceBox4.color = new Color32(255, 255, 255, 255);
            diceBox4.raycastTarget = true;
            diceBox5.color = new Color32(255, 255, 255, 255);
            diceBox5.raycastTarget = true;
            diceBox6.color = new Color32(255, 255, 255, 255);
            diceBox6.raycastTarget = true;
        }
    }
}
