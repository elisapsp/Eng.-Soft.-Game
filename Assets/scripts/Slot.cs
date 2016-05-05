using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler{

   
    
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }


    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop to " + gameObject.name);
        //eventData.pointerDrag.name é o objeto que está sendo carregado.
        //gameObject.name é o Slot.
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

       

    
        if (!item)
        {
            eventData.pointerDrag.transform.SetParent(transform);
        }
        else
        {
            //Debug.Log("Impossivel colocar o "+ eventData.pointerDrag.name + " neste espaço.\n O slot " + gameObject.name + " está ocupado pelo " + gameObject.GetComponentInChildren<Transform>().transform.gameObject.name);

            Debug.Log("Objeto que está ocupando o lugar: " + gameObject.transform.GetChild(0).name);
            Debug.Log("Pai do objeto que está ocupando o lugar: " + gameObject.name);
            Debug.Log("Objeto que quer entrar: " + eventData.pointerDrag.name);
            Debug.Log("Pai do objeto que quer entrar: " + eventData.pointerDrag.gameObject.transform.parent.name);

            //O objeto que está no lugar deve ir para o lugar do que está tentando entrar.
            //gameObject.transform.GetChild(0).transform.parent = eventData.pointerDrag.transform.parent;
            gameObject.transform.GetChild(0).SetParent(eventData.pointerDrag.transform.parent);
            //O objeto que está tentando entrar deve ir para o lugar que ele estava tentando.
            eventData.pointerDrag.transform.SetParent(transform);
        }
    }

    //Mostra cada objeto que o mouse passar por cima.
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter: " + gameObject.name);
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit: " + gameObject.name);
       
    }
}
