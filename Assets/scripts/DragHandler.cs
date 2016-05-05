using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    Vector3 startPosition;
    Transform startParent;
	public GameObject pedacoDeSoftwareFisico;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Seta o item que está sendo carregado.
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.position = startPosition;
		if (eventData.pointerCurrentRaycast.gameObject == null) { //se foi arrastado pra fora da UI
			this.GetComponent<Image>().enabled = false;
			pedacoDeSoftwareFisico.SetActive(true);
		}
    }
}
