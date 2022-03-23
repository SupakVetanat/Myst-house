using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IDropHandler
{
    [SerializeField] public int id;
    public void OnDrop(PointerEventData eventData)
    {
        if ((eventData.pointerDrag != null))
        {
            if (eventData.pointerDrag.GetComponent<DragDrop>().id == id)
            {
                FinalGamePlay.instance.numItem += 1;
                FinalGamePlay.instance.onItem += 1;
            }
            else
            {
                FinalGamePlay.instance.onItem += 1;
            }
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Destroy(eventData.pointerDrag.GetComponent<DragDrop>());
            eventData.pointerDrag.GetComponent<CanvasGroup>().alpha = 1f;
            gameObject.SetActive(false);
         }
    }
    private void Update()
    {
    }

}
