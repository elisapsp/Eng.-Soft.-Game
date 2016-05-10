using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class atualizaRecursos : MonoBehaviour {

    private string nomeRecurso;
    private GameObject recursos;
   

    // Use this for initialization
    void Start()
    {
        nomeRecurso = gameObject.transform.parent.name;
        recursos = GameObject.Find("GerenciarTime");

    }

    // Update is called once per frame
    void Update () {

        switch (nomeRecurso)
        {

            case "Desenvolvedores":
                gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().desenvolvedores.ToString();
                break;
            case "Testador 1":
                if (recursos.GetComponent<Recursos>().testador[0] == true)
                {
                    gameObject.GetComponent<Text>().text = "1";
                }
                else
                {
                    gameObject.GetComponent<Text>().text = "0";
                }
                break;
            case "Testador 2":
                if (recursos.GetComponent<Recursos>().testador[1] == true)
                {
                    gameObject.GetComponent<Text>().text = "1";
                }
                else
                {
                    gameObject.GetComponent<Text>().text = "0";
                }
                break;
            case "Testador 3":
                if (recursos.GetComponent<Recursos>().testador[2] == true)
                {
                    gameObject.GetComponent<Text>().text = "1";
                }
                else
                {
                    gameObject.GetComponent<Text>().text = "0";
                }
                break;
            case "Testador 4":
                if (recursos.GetComponent<Recursos>().testador[3] == true)
                {
                    gameObject.GetComponent<Text>().text = "1";
                }
                else
                {
                    gameObject.GetComponent<Text>().text = "0";
                }
                break;
            case "Controle de Versão":
                gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().controleVersao.ToString() + "/" + recursos.GetComponent<Recursos>().controleVersaoAbsoluto.ToString();
                break;
            case "Nivel do Depurador":
                gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().nivelDebug.ToString() + "/" + recursos.GetComponent<Recursos>().nivelDebugAbsoluto.ToString();
                break;
            case "Conhecimento SCRUM":
                string firstNumber;
                string secondNumber;
                if (recursos.GetComponent<Recursos>().ConhecimentoSCRUM == false)
                {
                    firstNumber = 0.ToString();
                }
                else
                {
                    firstNumber = 1.ToString();
                }

                if (recursos.GetComponent<Recursos>().ConhecimentoSCRUMAbsoluto == false)
                {
                    secondNumber = 0.ToString();
                }
                else
                {
                    secondNumber = 1.ToString();
                }

                gameObject.GetComponent<Text>().text = firstNumber + "/" + secondNumber;
                break;
            case "Organização de Tempo":
                gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().OrganizacaoTempo.ToString() + "/" + recursos.GetComponent<Recursos>().OrganizacaoTempoAbsoluto.ToString();
                break;
            case "Aumento de salário":
                gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().aumentoSalario.ToString() + "/" + recursos.GetComponent<Recursos>().aumentoSalarioAbsoluto.ToString();
                break;
            case "Práticas Motivacionais":
                gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().PraticasMotivacionais.ToString() + "/" + recursos.GetComponent<Recursos>().PraticasMotivacionaisAbsoluto.ToString();
                break;
            case "Café":
                gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().Cafe.ToString() + "/" + recursos.GetComponent<Recursos>().CafeAbsoluto.ToString();
                break;

            default:
                Debug.Log("O nome do Panel está diferente do nome escrito dentro do switch deste código [atualizaRecursos].");
                break;

        }
	


	}
}
