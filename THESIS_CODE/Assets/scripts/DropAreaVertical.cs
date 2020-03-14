using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropAreaVertical : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        DragVertical d = eventData.pointerDrag.GetComponent<DragVertical>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (eventData.pointerDrag == null)
            return;

        DragVertical d = eventData.pointerDrag.GetComponent<DragVertical>();
        if (d != null && d.placeholderParent == this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        DragVertical d = eventData.pointerDrag.GetComponent<DragVertical>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }

    }
}
