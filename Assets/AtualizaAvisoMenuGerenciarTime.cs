using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AtualizaAvisoMenuGerenciarTime : MonoBehaviour {

    private GameObject GerenciadorJogo;

    // Use this for initialization
    void Start () {
        GerenciadorJogo = GameObject.Find("GerenciadorJogo");
    }

   
	
	// Update is called once per frame
	void Update () {
        if (GerenciadorJogo.GetComponent<GerenciadorJogo>().GameWait == true)
        {
            gameObject.GetComponent<Text>().text = "ATENÇÃO! Antes de começar, você pode remanejar (adicionar ou remover) os recursos que quiser (exceto sua equipe de desenvolvedores, que não pode ser demitida nunca).";
        }
        else
        {
            gameObject.GetComponent<Text>().text = "IMPORTANTE! A fase de remanejamento acabou! Não é possível remanejar os recursos até o final deste trabalho! Só é possível adicionar recursos.";
        }
    }
}
