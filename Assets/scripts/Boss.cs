﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private GameObject tooltip;

    public GameObject painelPlaca;
    private GameObject tituloPlaca;
    private GameObject conteudoPlaca;

    public string textoTituloPlaca;
    public string textoConteudoPlaca;

    private GameObject GerenciadorJogo;


    // Use this for initialization
    void Start()
    {
        //Tooltip aperte enter para ler.
        tooltip = gameObject.transform.FindChild("tooltip").gameObject;



        GerenciadorJogo = GameObject.Find("GerenciadorJogo");


        tituloPlaca = painelPlaca.transform.FindChild("Titulo").gameObject;
        conteudoPlaca = painelPlaca.transform.FindChild("Conteudo").gameObject;


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        //Se quem colidir for um player.
        if (collision.tag == "Player")
        {
            GerenciadorJogo.GetComponent<OnePanelAtOnce>().cleanAllPanels();

            painelPlaca.SetActive(true);

            tituloPlaca.GetComponent<Text>().text = textoTituloPlaca;
            conteudoPlaca.GetComponent<Text>().text = textoConteudoPlaca;
        }

        OnPressEnter();
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        //Se quem colidir for um player.
        if (collision.tag == "Player")
        {
            painelPlaca.SetActive(false);
        }
    }


    void OnTriggerStay2D(Collider2D collision)
    {

        OnPressEnter();

    }

    public void OnPressEnter()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {

            if (painelPlaca.activeSelf == true)
            {
                painelPlaca.SetActive(false);
            }


        }

    }
}
