using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 dieSourcePosition;
    Transform dieSourceParent;
    Transform canvasTransform;
    private SoundManager sm;

    private void Awake()
    {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void Start()
    {
        canvasTransform = FindObjectsOfType<Canvas>()[1].transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        sm.PlaySound(sm.sounds[0]);
        itemBeingDragged = gameObject;
        dieSourcePosition = transform.position;
        dieSourceParent = transform.parent;
        itemBeingDragged.transform.SetParent(canvasTransform);
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        if (dieSourceParent.tag == "DrillingDiceTray1" || dieSourceParent.tag == "DrillingDiceTray2" || dieSourceParent.tag == "DrillingDiceTray3" || dieSourceParent.tag == "DrillingDiceTray4")
        {
            FindObjectOfType<DrillingPanel>().RemoveDice(dieSourceParent.tag);
            FindObjectOfType<DrillingPanel>().EnableDisableDiceBoxes();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (eventData.pointerEnter != null && eventData.pointerEnter.gameObject.tag == "SlotDiceTray")
        {
            PlaceDice(eventData);
            return;
        }

        Debug.Log("You just Entered: " + eventData.pointerEnter.gameObject.name);

        if (eventData.pointerEnter != null && eventData.pointerEnter.gameObject.tag == "ProcessingDiceTray")
        {
            PlaceDice(eventData);
            eventData.pointerEnter.transform.GetComponentInParent<ProcessingPanel>().EnableResultButton();
            return;
        }

        if (eventData.pointerEnter != null && (eventData.pointerEnter.gameObject.tag == "DrillingDiceTray1" || eventData.pointerEnter.gameObject.tag == "DrillingDiceTray3" || eventData.pointerEnter.gameObject.tag == "DrillingDiceTray5"))
        {
            PlaceDice(eventData);
            CheckForPairs(eventData);
            return;
        }
        else
        {
            CheckForPairs(eventData);
            return;
        }
    }

    private void CheckForPairs(PointerEventData eventData)
    {
        string dieTag = "dieTag";
        string dieTag2 = "dieTag2";

        if (eventData.pointerEnter.transform.tag == "DrillingDiceTray1" || eventData.pointerEnter.transform.tag == "DrillingDiceTray2")
        {
            dieTag = GetDie("slot1", eventData);
            dieTag2 = itemBeingDragged.gameObject.tag;
        }

        if (eventData.pointerEnter.transform.tag == "DrillingDiceTray3" || eventData.pointerEnter.transform.tag == "DrillingDiceTray4")
        {
            dieTag = GetDie("slot3", eventData);
            dieTag2 = itemBeingDragged.gameObject.tag;
        }

        if (eventData.pointerEnter.transform.tag == "DrillingDiceTray5" || eventData.pointerEnter.transform.tag == "DrillingDiceTray6")
        {
            dieTag = GetDie("slot5", eventData);
            dieTag2 = itemBeingDragged.gameObject.tag;
        }


        //Debug.Log("Tag for Slot1 is " + dieTag);
        //Debug.Log("Tag for Slot2 is " + dieTag2);

        if (dieTag == dieTag2)
        {
            //Debug.Log("Tags match!!");
            PlaceDice(eventData);
            eventData.pointerEnter.transform.GetComponentInParent<DrillingPanel>().EnableDisableDiceBoxes();
        }
        else if (dieTag == "")
        {
            PlaceDice(eventData);
        }
        else
            NoPlaceForDice();
    }

    private string GetDie(string value, PointerEventData eventData)
    {
        return eventData.pointerEnter.transform.GetComponentInParent<DrillingPanel>().GetDieInSlot(value);
    }

    private void PlaceDice(PointerEventData eventData)
    {
        sm.PlaySound(sm.sounds[0]);
        transform.SetParent(eventData.pointerEnter.transform);
        transform.position = eventData.pointerEnter.transform.position;
    }

    private void NoPlaceForDice()
    {
        transform.position = dieSourcePosition;
        transform.SetParent(dieSourceParent);
        itemBeingDragged = null;
    }
}
