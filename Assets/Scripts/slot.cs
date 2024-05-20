using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class slot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public RawImage image;
    [HideInInspector] public Transform parentDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsFirstSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentDrag);
        image.raycastTarget = true;
    }
}
