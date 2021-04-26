using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessingPanel : MonoBehaviour
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

    public void EnableResultButton()
    {
        if (!resultButton.interactable)
            resultButton.interactable = true;
    }

    public void DisableProcessingDiceBoxes()
    {
        diceBox1.color = new Color32(255, 0, 0, 255);
        diceBox1.raycastTarget = false;
        diceBox2.color = new Color32(255, 0, 0, 255);
        diceBox2.raycastTarget = false;
        diceBox3.color = new Color32(255, 0, 0, 255);
        diceBox3.raycastTarget = false;
        diceBox4.color = new Color32(255, 0, 0, 255);
        diceBox4.raycastTarget = false;
        diceBox5.color = new Color32(255, 0, 0, 255);
        diceBox5.raycastTarget = false;
        diceBox6.color = new Color32(255, 0, 0, 255);
        diceBox6.raycastTarget = false;
    }

    public void EnableProcessingDiceBoxes()
    {
        diceBox1.color = new Color32(255, 255, 255, 255);
        diceBox1.raycastTarget = true;
        diceBox2.color = new Color32(255, 255, 255, 255);
        diceBox2.raycastTarget = true;
        diceBox3.color = new Color32(255, 255, 255, 255);
        diceBox3.raycastTarget = true;
        diceBox4.color = new Color32(255, 255, 255, 255);
        diceBox4.raycastTarget = true;
        diceBox5.color = new Color32(255, 255, 255, 255);
        diceBox5.raycastTarget = true;
        diceBox6.color = new Color32(255, 255, 255, 255);
        diceBox6.raycastTarget = true;
    }

    public int GetTotalFromDice()
    {
        int total = 0;

        if (diceBox1.GetComponentInChildren<DragHandler>())
        {
            total += WhatIsTheDieNumber(diceBox1.GetComponentInChildren<DragHandler>().gameObject);
        }
        if (diceBox2.GetComponentInChildren<DragHandler>())
        {
            total += WhatIsTheDieNumber(diceBox2.GetComponentInChildren<DragHandler>().gameObject);
        }
        if (diceBox3.GetComponentInChildren<DragHandler>())
        {
            total += WhatIsTheDieNumber(diceBox3.GetComponentInChildren<DragHandler>().gameObject);
        }
        if (diceBox4.GetComponentInChildren<DragHandler>())
        {
            total += WhatIsTheDieNumber(diceBox4.GetComponentInChildren<DragHandler>().gameObject);
        }
        if (diceBox5.GetComponentInChildren<DragHandler>())
        {
            total += WhatIsTheDieNumber(diceBox5.GetComponentInChildren<DragHandler>().gameObject);
        }
        if (diceBox6.GetComponentInChildren<DragHandler>())
        {
            total += WhatIsTheDieNumber(diceBox6.GetComponentInChildren<DragHandler>().gameObject);
        }

        return total;
    }

    private int WhatIsTheDieNumber(GameObject go)
    {
        int dieNumber = 0;

        switch(go.tag)
        {
            case "Dice1":
                dieNumber = 1;
                break;
            case "Dice2":
                dieNumber = 2;
                break;
            case "Dice3":
                dieNumber = 3;
                break;
            case "Dice4":
                dieNumber = 4;
                break;
            case "Dice5":
                dieNumber = 5;
                break;
            case "Dice6":
                dieNumber = 6;
                break;
        }

        return dieNumber;
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
}
