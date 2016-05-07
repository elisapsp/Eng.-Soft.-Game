using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class removePontos : MonoBehaviour {

    private GameObject recursos;


    private GameObject Panel;
    private string nomeRecurso;

    // Use this for initialization
    void Start()
    {

        recursos = GameObject.Find("GerenciarTime");


    }

    public void removeRecursos()
    {
      
        
            Panel = gameObject.transform.parent.gameObject;
            nomeRecurso = Panel.transform.FindChild("Nome").gameObject.GetComponent<Text>().text;

            switch (nomeRecurso)
            {
                case "Desenvolvedores":

                        recursos.GetComponent<Recursos>().desenvolvedores--;
                        recursos.GetComponent<Recursos>().PontosTotais++;
                    


                    break;
                case "Testador 1":
                        recursos.GetComponent<Recursos>().testador[0] = false;
                        recursos.GetComponent<Recursos>().PontosTotais++;
                   
                    break;
                case "Testador 2":
                        recursos.GetComponent<Recursos>().testador[1] = false;
                        recursos.GetComponent<Recursos>().PontosTotais++;
        
                    break;
                case "Testador 3":
                    
                        recursos.GetComponent<Recursos>().testador[2] = false;
                        recursos.GetComponent<Recursos>().PontosTotais++;
                    
                    break;
                case "Testador 4":
                    
                        recursos.GetComponent<Recursos>().testador[3] = false;
                        recursos.GetComponent<Recursos>().PontosTotais++;
                    

                    break;
                case "Controle de Versão":
                        recursos.GetComponent<Recursos>().controleVersao--;
                        recursos.GetComponent<Recursos>().PontosTotais++;
                    
                    break;
                case "Nivel do Depurador":
                        recursos.GetComponent<Recursos>().nivelDebug--;
                        recursos.GetComponent<Recursos>().PontosTotais++;
                    
                    break;
                case "Conhecimento SCRUM":
                   
                        recursos.GetComponent<Recursos>().ConhecimentoSCRUM = false;
                        recursos.GetComponent<Recursos>().PontosTotais++;
                   

                    break;
                case "Organização de Tempo":
                        recursos.GetComponent<Recursos>().OrganizacaoTempo--;
                        recursos.GetComponent<Recursos>().PontosTotais++;

                    break;
                case "Aumento de salário":
                   
                        recursos.GetComponent<Recursos>().aumentoSalario--;
                        recursos.GetComponent<Recursos>().PontosTotais++;
                   

                    break;
                case "Práticas Motivacionais":
                        recursos.GetComponent<Recursos>().PraticasMotivacionais--;
                        recursos.GetComponent<Recursos>().PontosTotais++;
                    
                    break;
                case "Café":
                        recursos.GetComponent<Recursos>().Cafe--;
                        recursos.GetComponent<Recursos>().PontosTotais++;
        
                    break;
                default:
                    Debug.Log("Nome do recurso no painel está diferente do nome no switch do script.");
                    break;

            }

        
    }

  
	
	// Update is called once per frame
	void Update () {
	
	}
}
