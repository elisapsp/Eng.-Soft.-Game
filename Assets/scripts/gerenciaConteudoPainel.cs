using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gerenciaConteudoPainel : MonoBehaviour {

    private string nomeRecurso;
    private GameObject recursos;
    private GameObject botaoAdd;
    private GameObject botaoRm;
    private GameObject pontosDistrib;

    // Use this for initialization
    void Start () {
        recursos = GameObject.Find("GerenciarTime");
        nomeRecurso = gameObject.transform.FindChild("Nome").gameObject.GetComponent<Text>().text;
        botaoAdd = gameObject.transform.FindChild("Button +").gameObject;
        botaoRm = gameObject.transform.FindChild("Button -").gameObject;
        pontosDistrib = gameObject.transform.FindChild("Panel").gameObject.transform.FindChild("Text").gameObject;
    }

	
	// Update is called once per frame
	void Update () {

        switch (nomeRecurso)
        {
            case "Desenvolvedores":
                
                if (recursos.GetComponent<Recursos>().desenvolvedores == recursos.GetComponent<Recursos>().maxDesenvolvedores)
                {
                    botaoAdd.GetComponent<Button>().interactable = false;
                    botaoAdd.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoAdd.GetComponent<Button>().interactable = true;
                    botaoAdd.GetComponent<Image>().color = Color.white;

                }

                    //A contratação de desenvolvedores é uma atividade que não pode ser desfeita.
                    botaoRm.GetComponent<Button>().interactable = false;
                    botaoRm.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                
                
                pontosDistrib.GetComponent<Text>().text = recursos.GetComponent<Recursos>().desenvolvedores.ToString();


                break;
            case "Testador 1":
                if (recursos.GetComponent<Recursos>().testador[0] == recursos.GetComponent<Recursos>().maxTestador1)
                {
                    botaoAdd.GetComponent<Button>().interactable = false;
                    botaoAdd.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoAdd.GetComponent<Button>().interactable = true;
                    botaoAdd.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().testador[0] == recursos.GetComponent<Recursos>().minBool)
                {

                    botaoRm.GetComponent<Button>().interactable = false;
                    botaoRm.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoRm.GetComponent<Button>().interactable = true;
                    botaoRm.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().testador[0])
                {
                    pontosDistrib.GetComponent<Text>().text = "1";
                }
                else
                {
                    pontosDistrib.GetComponent<Text>().text = "0";
                }
                
                break;
            case "Testador 2":
                if (recursos.GetComponent<Recursos>().testador[1] == recursos.GetComponent<Recursos>().maxTestador2)
                {
                    botaoAdd.GetComponent<Button>().interactable = false;
                    botaoAdd.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoAdd.GetComponent<Button>().interactable = true;
                    botaoAdd.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().testador[1] == recursos.GetComponent<Recursos>().minBool)
                {

                    botaoRm.GetComponent<Button>().interactable = false;
                    botaoRm.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoRm.GetComponent<Button>().interactable = true;
                    botaoRm.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().testador[1])
                {
                    pontosDistrib.GetComponent<Text>().text = "1";
                }
                else
                {
                    pontosDistrib.GetComponent<Text>().text = "0";
                }
                break;
            case "Testador 3":
                if (recursos.GetComponent<Recursos>().testador[2] == recursos.GetComponent<Recursos>().maxTestador3)
                {
                    botaoAdd.GetComponent<Button>().interactable = false;
                    botaoAdd.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoAdd.GetComponent<Button>().interactable = true;
                    botaoAdd.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().testador[2] == recursos.GetComponent<Recursos>().minBool)
                {

                    botaoRm.GetComponent<Button>().interactable = false;
                    botaoRm.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoRm.GetComponent<Button>().interactable = true;
                    botaoRm.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().testador[2])
                {
                    pontosDistrib.GetComponent<Text>().text = "1";
                }
                else
                {
                    pontosDistrib.GetComponent<Text>().text = "0";
                }
                break;
            case "Testador 4":
                if (recursos.GetComponent<Recursos>().testador[3] == recursos.GetComponent<Recursos>().maxTestador4)
                {
                    botaoAdd.GetComponent<Button>().interactable = false;
                    botaoAdd.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoAdd.GetComponent<Button>().interactable = true;
                    botaoAdd.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().testador[3] == recursos.GetComponent<Recursos>().minBool)
                {

                    botaoRm.GetComponent<Button>().interactable = false;
                    botaoRm.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoRm.GetComponent<Button>().interactable = true;
                    botaoRm.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().testador[3])
                {
                    pontosDistrib.GetComponent<Text>().text = "1";
                }
                else
                {
                    pontosDistrib.GetComponent<Text>().text = "0";
                }

                break;
            case "Controle de Versão":
                if (recursos.GetComponent<Recursos>().controleVersaoAbsoluto == recursos.GetComponent<Recursos>().maxControleVersao)
                {
                    botaoAdd.GetComponent<Button>().interactable = false;
                    botaoAdd.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoAdd.GetComponent<Button>().interactable = true;
                    botaoAdd.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().controleVersaoAbsoluto == recursos.GetComponent<Recursos>().minInt)
                {

                    botaoRm.GetComponent<Button>().interactable = false;
                    botaoRm.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoRm.GetComponent<Button>().interactable = true;
                    botaoRm.GetComponent<Image>().color = Color.white;

                }
                pontosDistrib.GetComponent<Text>().text = recursos.GetComponent<Recursos>().controleVersaoAbsoluto.ToString();


                break;
            case "Nivel do Depurador":
                if (recursos.GetComponent<Recursos>().nivelDebugAbsoluto == recursos.GetComponent<Recursos>().maxNivelDebug)
                {
                    botaoAdd.GetComponent<Button>().interactable = false;
                    botaoAdd.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoAdd.GetComponent<Button>().interactable = true;
                    botaoAdd.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().nivelDebugAbsoluto == recursos.GetComponent<Recursos>().minInt)
                {

                    botaoRm.GetComponent<Button>().interactable = false;
                    botaoRm.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoRm.GetComponent<Button>().interactable = true;
                    botaoRm.GetComponent<Image>().color = Color.white;

                }
                pontosDistrib.GetComponent<Text>().text = recursos.GetComponent<Recursos>().nivelDebugAbsoluto.ToString();


                break;
            case "Conhecimento SCRUM":
                if (recursos.GetComponent<Recursos>().ConhecimentoSCRUMAbsoluto == recursos.GetComponent<Recursos>().maxConhecimentoSCRUM)
                {
                    botaoAdd.GetComponent<Button>().interactable = false;
                    botaoAdd.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoAdd.GetComponent<Button>().interactable = true;
                    botaoAdd.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().ConhecimentoSCRUMAbsoluto == recursos.GetComponent<Recursos>().minBool)
                {

                    botaoRm.GetComponent<Button>().interactable = false;
                    botaoRm.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoRm.GetComponent<Button>().interactable = true;
                    botaoRm.GetComponent<Image>().color = Color.white;

                }
                if (recursos.GetComponent<Recursos>().ConhecimentoSCRUMAbsoluto)
                {
                    pontosDistrib.GetComponent<Text>().text = "1";
                }
                else
                {
                    pontosDistrib.GetComponent<Text>().text = "0";
                }


                break;
            case "Organização de Tempo":
                if (recursos.GetComponent<Recursos>().OrganizacaoTempoAbsoluto == recursos.GetComponent<Recursos>().maxOrganizacaoTempo)
                {
                    botaoAdd.GetComponent<Button>().interactable = false;
                    botaoAdd.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoAdd.GetComponent<Button>().interactable = true;
                    botaoAdd.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().OrganizacaoTempoAbsoluto == recursos.GetComponent<Recursos>().minInt)
                {

                    botaoRm.GetComponent<Button>().interactable = false;
                    botaoRm.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoRm.GetComponent<Button>().interactable = true;
                    botaoRm.GetComponent<Image>().color = Color.white;

                }
                pontosDistrib.GetComponent<Text>().text = recursos.GetComponent<Recursos>().OrganizacaoTempoAbsoluto.ToString();
                break;
            case "Aumento de salário":
                if (recursos.GetComponent<Recursos>().aumentoSalarioAbsoluto == recursos.GetComponent<Recursos>().maxAumentoSalario)
                {
                    botaoAdd.GetComponent<Button>().interactable = false;
                    botaoAdd.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoAdd.GetComponent<Button>().interactable = true;
                    botaoAdd.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().aumentoSalarioAbsoluto == recursos.GetComponent<Recursos>().minInt)
                {

                    botaoRm.GetComponent<Button>().interactable = false;
                    botaoRm.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoRm.GetComponent<Button>().interactable = true;
                    botaoRm.GetComponent<Image>().color = Color.white;

                }
                pontosDistrib.GetComponent<Text>().text = recursos.GetComponent<Recursos>().aumentoSalarioAbsoluto.ToString();
                break;
            case "Práticas Motivacionais":
                if (recursos.GetComponent<Recursos>().PraticasMotivacionaisAbsoluto == recursos.GetComponent<Recursos>().maxPraticasMotivacionais)
                {
                    botaoAdd.GetComponent<Button>().interactable = false;
                    botaoAdd.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoAdd.GetComponent<Button>().interactable = true;
                    botaoAdd.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().PraticasMotivacionaisAbsoluto == recursos.GetComponent<Recursos>().minInt)
                {

                    botaoRm.GetComponent<Button>().interactable = false;
                    botaoRm.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoRm.GetComponent<Button>().interactable = true;
                    botaoRm.GetComponent<Image>().color = Color.white;

                }
                pontosDistrib.GetComponent<Text>().text = recursos.GetComponent<Recursos>().PraticasMotivacionaisAbsoluto.ToString();
                break;
            case "Café":
                if (recursos.GetComponent<Recursos>().CafeAbsoluto == recursos.GetComponent<Recursos>().maxCafe)
                {
                    botaoAdd.GetComponent<Button>().interactable = false;
                    botaoAdd.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoAdd.GetComponent<Button>().interactable = true;
                    botaoAdd.GetComponent<Image>().color = Color.white;

                }

                if (recursos.GetComponent<Recursos>().CafeAbsoluto == recursos.GetComponent<Recursos>().minInt)
                {

                    botaoRm.GetComponent<Button>().interactable = false;
                    botaoRm.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                }
                else
                {
                    botaoRm.GetComponent<Button>().interactable = true;
                    botaoRm.GetComponent<Image>().color = Color.white;

                }
                pontosDistrib.GetComponent<Text>().text = recursos.GetComponent<Recursos>().CafeAbsoluto.ToString();
                break;
            case "Ligar para Cliente":
                
                botaoAdd.GetComponent<Button>().interactable = false;
                botaoAdd.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);
                botaoRm.GetComponent<Button>().interactable = false;
                botaoRm.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1);

                break;
            default:
                Debug.Log("Nome do recurso no painel está diferente do nome no switch do script.");
                break;


        }
        

	}
}
