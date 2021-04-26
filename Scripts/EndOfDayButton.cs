using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfDayButton : MonoBehaviour
{
    public GameObject endOfDayButton;
    public Text endOfDayText;

    public void SetButtonDisableStatus(bool value)
    {
        endOfDayButton.GetComponent<Button>().interactable = value;
    }

    public void SetText(string text)
    {
        endOfDayText.text = text;
    }
}
