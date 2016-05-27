using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class atualizaRecursos : MonoBehaviour {

    private string nomeRecurso;
    private GameObject recursos;
    private GameObject Player;

    // Use this for initialization
    void Start()
    {
        nomeRecurso = gameObject.transform.parent.name;
        recursos = GameObject.Find("GerenciarTime");
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update () {

        switch (nomeRecurso)
        {

            case "Desenvolvedores":
                gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().desenvolvedores.ToString() + "/" + recursos.GetComponent<Recursos>().maxDesenvolvedores.ToString();
                if (recursos.GetComponent<Recursos>().desenvolvedores == 0)
                {
                    gameObject.GetComponent<Text>().color = Color.red;
                }
                else 
                {
                    gameObject.GetComponent<Text>().color = Color.white;
                }

                break;
            case "Testador 1":
                if (recursos.GetComponent<Recursos>().testador[0] == true)
                {
                    gameObject.GetComponent<Text>().text = "1/1";
                    gameObject.GetComponent<Text>().color = Color.white;
                }
                else
                {
                    gameObject.GetComponent<Text>().text = "0/1";
                    gameObject.GetComponent<Text>().color = Color.red;
                }

                break;
            case "Testador 2":
                if (recursos.GetComponent<Recursos>().testador[1] == true)
                {
                    gameObject.GetComponent<Text>().text = "1/1";
                    gameObject.GetComponent<Text>().color = Color.white;
                }
                else
                {
                    gameObject.GetComponent<Text>().text = "0/1";
                    gameObject.GetComponent<Text>().color = Color.red;
                }
                break;
            case "Testador 3":
                if (recursos.GetComponent<Recursos>().testador[2] == true)
                {
                    gameObject.GetComponent<Text>().text = "1/1";
                    gameObject.GetComponent<Text>().color = Color.white;
                }
                else
                {
                    gameObject.GetComponent<Text>().text = "0/1";
                    gameObject.GetComponent<Text>().color = Color.red;
                }
                break;
            case "Testador 4":
                if (recursos.GetComponent<Recursos>().testador[3] == true)
                {
                    gameObject.GetComponent<Text>().text = "1/1";
                    gameObject.GetComponent<Text>().color = Color.white;
                }
                else
                {
                    gameObject.GetComponent<Text>().text = "0/1";
                    gameObject.GetComponent<Text>().color = Color.red;
                }
                break;
            case "Controle de Versão":
                gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().controleVersao.ToString() + "/" + recursos.GetComponent<Recursos>().maxControleVersao.ToString();
                if (recursos.GetComponent<Recursos>().controleVersao == 0)
                {
                    gameObject.GetComponent<Text>().color = Color.red;
                }
                else
                {
                    gameObject.GetComponent<Text>().color = Color.white;
                }
                break;
            case "Nivel do Depurador":
                gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().nivelDebug.ToString() + "/" + recursos.GetComponent<Recursos>().maxNivelDebug.ToString();
                if (recursos.GetComponent<Recursos>().nivelDebug == 0)
                {
                    gameObject.GetComponent<Text>().color = Color.red;
                }
                else
                {
                    gameObject.GetComponent<Text>().color = Color.white;
                }
                break;
            case "Conhecimento SCRUM":
                string firstNumber;

                if (recursos.GetComponent<Recursos>().ConhecimentoSCRUM == false)
                {
                    firstNumber = 0.ToString();
                    gameObject.GetComponent<Text>().color = Color.red;
                }
                else
                {
                    firstNumber = 1.ToString();
                    gameObject.GetComponent<Text>().color = Color.white;
                }

                
                gameObject.GetComponent<Text>().text = firstNumber + "/" + 1.ToString();

                break;
            case "Organização de Tempo":
                gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().OrganizacaoTempo.ToString() + "/" + recursos.GetComponent<Recursos>().maxOrganizacaoTempo.ToString();
                if (recursos.GetComponent<Recursos>().OrganizacaoTempo == 0)
                {
                    gameObject.GetComponent<Text>().color = Color.red;
                }
                else
                {
                    gameObject.GetComponent<Text>().color = Color.white;
                }
                break;
            case "Aumento de salário":
                gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().aumentoSalario.ToString() + "/" + recursos.GetComponent<Recursos>().maxAumentoSalario.ToString();
                if (Player.GetComponent<usaRecursos>().usandoAumentoSalario == true)
                {
                    gameObject.GetComponent<Text>().color = Color.green;
                }
                else if (recursos.GetComponent<Recursos>().aumentoSalario == 0)
                {
                    gameObject.GetComponent<Text>().color = Color.red;
                }
                else
                {
                    gameObject.GetComponent<Text>().color = Color.white;
                }
                break;
            case "Práticas Motivacionais":
                gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().PraticasMotivacionais.ToString() + "/" + recursos.GetComponent<Recursos>().maxPraticasMotivacionais.ToString();
                if (Player.GetComponent<usaRecursos>().usandoPraticasMotivacionais == true)
                {
                    gameObject.GetComponent<Text>().color = Color.green;
                }
                else if (recursos.GetComponent<Recursos>().PraticasMotivacionais == 0)
                {
                    gameObject.GetComponent<Text>().color = Color.red;
                }
                else
                {
                    gameObject.GetComponent<Text>().color = Color.white;
                }
                break;
            case "Café":
                gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().Cafe.ToString() + "/" + recursos.GetComponent<Recursos>().maxCafe.ToString();
                if (Player.GetComponent<usaRecursos>().usandoCafe == true)
                {
                    gameObject.GetComponent<Text>().color = Color.green;
                }
                else if (recursos.GetComponent<Recursos>().Cafe == 0)
                {
                    gameObject.GetComponent<Text>().color = Color.red;
                }
                else
                {
                    gameObject.GetComponent<Text>().color = Color.white;
                }
                break;

            default:
                Debug.Log("O nome do Panel está diferente do nome escrito dentro do switch deste código [atualizaRecursos].");
                break;

        }
	


	}
}
