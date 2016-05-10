using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class adicionaPontos : MonoBehaviour {

    private GameObject recursos;


    private GameObject Panel;
    private string nomeRecurso;

    // Use this for initialization
    void Start()
    {

        recursos = GameObject.Find("GerenciarTime");


    }

    public void adicionaRecursos()
    {
        if (recursos.GetComponent<Recursos>().PontosTotais > 0) { 
        Panel = gameObject.transform.parent.gameObject;
        nomeRecurso = Panel.transform.FindChild("Nome").gameObject.GetComponent<Text>().text;

        switch (nomeRecurso)
        {
            case "Desenvolvedores":
                    
                        recursos.GetComponent<Recursos>().desenvolvedores++;
                        recursos.GetComponent<Recursos>().PontosTotais--;
                    
                   
                    break;
            case "Testador 1":
                    
                        recursos.GetComponent<Recursos>().testador[0] = true;
                        recursos.GetComponent<Recursos>().PontosTotais--;
                    
                   
                    break;
            case "Testador 2":
                        recursos.GetComponent<Recursos>().testador[1] = true;
                        recursos.GetComponent<Recursos>().PontosTotais--;
                    break;
            case "Testador 3":
                        recursos.GetComponent<Recursos>().testador[2] = true;
                        recursos.GetComponent<Recursos>().PontosTotais--;
                    
            break;
            case "Testador 4":
                        recursos.GetComponent<Recursos>().testador[3] = true;
                        recursos.GetComponent<Recursos>().PontosTotais--;
                    
                    break;
            case "Controle de Versão":
                    recursos.GetComponent<Recursos>().controleVersaoAbsoluto++;
                    recursos.GetComponent<Recursos>().controleVersao++;
                        recursos.GetComponent<Recursos>().PontosTotais--;
                    
                    break;
            case "Nivel do Depurador":
                    recursos.GetComponent<Recursos>().nivelDebugAbsoluto++;
                    recursos.GetComponent<Recursos>().nivelDebug++;
                        recursos.GetComponent<Recursos>().PontosTotais--;
                    
                    break;
            case "Conhecimento SCRUM":
                    recursos.GetComponent<Recursos>().ConhecimentoSCRUMAbsoluto = true;
                    recursos.GetComponent<Recursos>().ConhecimentoSCRUM = true;
                        recursos.GetComponent<Recursos>().PontosTotais--;
                    
                    break;
            case "Organização de Tempo":
                    recursos.GetComponent<Recursos>().OrganizacaoTempoAbsoluto++;
                    recursos.GetComponent<Recursos>().OrganizacaoTempo++;
                        recursos.GetComponent<Recursos>().PontosTotais--;
                    
                    break;
            case "Aumento de salário":
                    recursos.GetComponent<Recursos>().aumentoSalarioAbsoluto++;
                    recursos.GetComponent<Recursos>().aumentoSalario++;
                        recursos.GetComponent<Recursos>().PontosTotais--;
                    
                    break;
            case "Práticas Motivacionais":
                    recursos.GetComponent<Recursos>().PraticasMotivacionaisAbsoluto++;
                    recursos.GetComponent<Recursos>().PraticasMotivacionais++;
                        recursos.GetComponent<Recursos>().PontosTotais--;
                    
                    break;
            case "Café":
                    recursos.GetComponent<Recursos>().CafeAbsoluto++;
                    recursos.GetComponent<Recursos>().Cafe++;
                        recursos.GetComponent<Recursos>().PontosTotais--;
                    
                    break;
            default:
                Debug.Log("Nome do recurso no painel está diferente do nome no switch do script.");
                break;

        }

        }
    }

	
	
	// Update is called once per frame
	void Update () {
	
	}
}
