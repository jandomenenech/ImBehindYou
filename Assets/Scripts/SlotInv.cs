using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotInv : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        slot draggableItem = dropped.GetComponent<slot>();
        if (draggableItem != null)
        {
            if (transform.childCount == 0)
            {
               
                draggableItem.parentDrag = transform;
                draggableItem.transform.SetParent(transform);
                draggableItem.transform.localPosition = Vector3.zero;
            }
            else
            {
                
                Transform previousParent = draggableItem.parentDrag;
                Transform newParent = transform;

                draggableItem.parentDrag = newParent;
                draggableItem.transform.SetParent(newParent);
                draggableItem.transform.localPosition = Vector3.zero;

               
                draggableItem = transform.GetChild(0).GetComponent<slot>();
                draggableItem.parentDrag = previousParent;
                draggableItem.transform.SetParent(previousParent);
                draggableItem.transform.localPosition = Vector3.zero;
            }
        }
    }
}
