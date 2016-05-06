using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler{

    public string color;

    /*
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
    */
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop to " + gameObject.name);
        //eventData.pointerDrag.name é o objeto que está sendo carregado.
        //gameObject.name é o Slot.
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

       

    /*
        if (!item)
        {
            Debug.Log("TESTE");
            eventData.pointerDrag.transform.SetParent(transform);
        }
        */
        /*
        else
        {
        */
            //Debug.Log("Impossivel colocar o "+ eventData.pointerDrag.name + " neste espaço.\n O slot " + gameObject.name + " está ocupado pelo " + gameObject.GetComponentInChildren<Transform>().transform.gameObject.name);
            
            Debug.Log("Objeto que está ocupando o lugar: " + gameObject.transform.GetChild(0).name);
            Debug.Log("Pai do objeto que está ocupando o lugar: " + gameObject.name);
            Debug.Log("Objeto que quer entrar: " + eventData.pointerDrag.name);
            Debug.Log("Pai do objeto que quer entrar: " + eventData.pointerDrag.gameObject.transform.parent.name);

        if (eventData.pointerDrag.name == gameObject.name)
        {
            //O objeto que está no lugar deve ir para o lugar do que está tentando entrar.
            //gameObject.transform.GetChild(0).transform.parent = eventData.pointerDrag.transform.parent;
            gameObject.transform.GetChild(0).SetParent(eventData.pointerDrag.transform.parent);
            //O objeto que está tentando entrar deve ir para o lugar que ele estava tentando.
            eventData.pointerDrag.transform.SetParent(transform);
        }
        
        /*
    }
    */
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

    void Update()
    {
        //Se exisitir o pedacoSoftware naquele slot (no objeto "Vazio" do slot).
        if (transform.GetChild(0).GetComponent<Image>().enabled == true)
        {
            //Coloca a cor do slot com a mesma cor do pedacoSoftware qeu está ocupando o objetoVazio.
            gameObject.GetComponent<Image>().color = transform.GetChild(0).GetComponent<Image>().color;
        }
        else
        {
            //Senão, reseta as cores para o padrão.
            gameObject.GetComponent<Image>().color = new Color(248f / 255f, 248f / 255f, 248f / 255f, 1f);
            transform.GetChild(0).GetComponent<Image>().color = new Color(248f / 255f, 248f / 255f, 248f / 255f, 1f);
            transform.GetChild(0).name = "Vazio";
        }
       
        //Adiciona cor ao slot.
        //gameObject.GetComponent<Image>().color = Color.red;

    }
}
