using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RerollButton : MonoBehaviour
{
    public GameObject rerollButton;

    public void RerollDiceInDiceTray(GameObject diceTray)
    {
        diceTray.GetComponentInChildren<DiceTray>().DestroyAllChildren();
        diceTray.GetComponentInChildren<DiceTray>().RandomizeDiceTray(true);
    }

    public void SetButtonDisableStatus(bool value)
    {
        rerollButton.GetComponentInChildren<Button>().interactable = value;
    }

}
