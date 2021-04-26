using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollResultDieButton : AllMyChildren
{
    public GameObject[] dice;
    public GameObject resultButton;
    private bool resultDieOutcome;

    public bool RandomizeResultDie()
    {
        Transform[] diceTraySlots = GetComponentsInChildren<Transform>();
        foreach (Transform transform in diceTraySlots)
        {
            if (transform.CompareTag("ResultSlotDiceTray"))
            {
                CheckForChild(transform);
                GameObject die = GetRandomDie();
                GameObject go = Instantiate(die);
                go.transform.SetParent(transform);
                go.transform.position = transform.position;
                go.GetComponent<RotateDice>().SetCanRotate(true);
                resultDieOutcome = ResultDieOutcome(die);
            }
        }
        return resultDieOutcome;
    }

    private void CheckForChild(Transform transform)
    {
        if (HasChild(transform))
            DestroyChild(transform);
    }

    public GameObject GetRandomDie()
    {
        int randomNumber = Random.Range(0, 6);
        return dice[randomNumber];
    }

    private void RotateDie(GameObject go)
    {
        for (int i = 0; i < 3; i++)
        {
            go.transform.Rotate(360.0f, 0.0f, 0.0f, Space.Self);
        }
    }

    private bool ResultDieOutcome(GameObject die)
    {
        bool result = false;

        if (die.CompareTag("ResultGood"))
            result = true;

        return result;
    }

    public void SetButtonDisableStatus(bool value)
    {
        resultButton.GetComponentInChildren<Button>().interactable = value;
    }

    public override bool CheckForDie()
    {
        throw new System.NotImplementedException();
    }

    public override void DestroyAllChildren()
    {
        Transform[] diceTraySlots = GetComponentsInChildren<Transform>();
        foreach (Transform transform in diceTraySlots)
        {
            if (transform.CompareTag("ResultSlotDiceTray"))
            {
                CheckForChild(transform);
            }
        }
    }
}
