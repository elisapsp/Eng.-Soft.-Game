using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class Inventory : MonoBehaviour, IHasChanged {



	public Text inventoryText;
	[SerializeField]
	private Sprite[] pedacos;
    private Transform[] slots;
	
	void Awake() {
		slots = GetComponentsInChildren<Slot>().Select(s => s.transform).ToArray();
	}
	
    void Start()
    {
        HasChanged();
    }

    public void HasChanged()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append(" - ");
        foreach (Transform slotTransform in slots)
        {
            //GameObject item = slotTransform.GetComponent<Slot>().item;
            /*
            if (item)
            {
                builder.Append(item.name);
                builder.Append(" - ");
            }
            */
        }
        //inventoryText.text = builder.ToString();
    }

    public int indentificaTipo(string nomeSlot)
    {
        if (nomeSlot == "Tipo1")
        {
            return 1;
        }
        else if (nomeSlot == "Tipo2")
        {
            return 2;
        }
        else if (nomeSlot == "Tipo3")
        {
            return 3;
        }
        else if (nomeSlot == "Tipo4")
        {
            return 4;
        }

        return -1;
    }

    public void testaPedacosSoftware(bool[] testadorDoTipo)
    {
        
        int indexTipo;
        int Tipo;

        int totalPedacosSoftware = 0;
        int pedacosFuncionando = 0;
        int pedacosComDefeito = 0;
        int pedacosNaoTestados = 0;

        //Atualiza os slots.
        slots = GetComponentsInChildren<Slot>().Select(s => s.transform).ToArray();

        foreach (Transform transf in slots)
        {
           

            Image image = transf.GetChild(0).GetComponent<Image>();
            //Se o pedacoDeSoftware estiver lá.
            if (image.enabled == true)
            {
                //Conta o numero de pedacosDeSoftware existentes.
                totalPedacosSoftware++;

                Tipo = indentificaTipo(transf.name);
                indexTipo = Tipo - 1;

                //Se testador do tipo do software tiver disponivel (contratado pelos recursos).
                if (testadorDoTipo[indexTipo])
                {

                    //Verifica o tipo do software.

                    //Se o pedacoSoftware não estiver funcionando
                    if (transf.GetChild(0).GetComponent<Image>().GetComponent<DragHandler>().pedacoDeSoftwareFisico.GetComponent<pedacoSoftware>().funciona == false)
                    {

                        transf.GetChild(0).GetComponent<Image>().enabled = false;
                        transf.GetChild(0).GetComponent<Image>().GetComponent<DragHandler>().pedacoDeSoftwareFisico.GetComponent<pedacoSoftware>().color = "black";
                        transf.GetChild(0).GetComponent<Image>().GetComponent<DragHandler>().pedacoDeSoftwareFisico.SetActive(true);

                        pedacosComDefeito++;
                       
                    }
                    else
                    {
                        pedacosFuncionando++;
                        Debug.Log("Instancia funcionando perfeitamente");
                    }

                }
                else
                {
                    pedacosNaoTestados++;
                    Debug.Log("Não foi possível testar o pedacoSoftware do tipo" + Tipo.ToString() + ". Testador para este tipo não está disponível no time.");
                }
                

            }


        }
        Debug.Log("Numero de pedacos de Software desenvolvidos: " + totalPedacosSoftware + "\n");
        Debug.Log("Numero de pedacos de Software com defeitos encontrados:" + pedacosComDefeito.ToString() + "\n");
        Debug.Log("Numero de pedacos de Software funcionando:" + pedacosFuncionando.ToString() + "\n");
        Debug.Log("Numero de pedacos de Software não testados:" + pedacosNaoTestados.ToString() + " (Motivo: Testadores para os respectivos pedacos de Software não foram contratados" + "\n");
    }

	public int AdicionaTipoDeSoftware(pedacoSoftware pedaco) {
        Debug.Log(pedaco.color);
        //Contem a string Tipo<numero do pedacoSoftware>.
        string TipoPedacoSoftware = "Tipo" + pedaco.tipo.ToString();

        //Atualiza os slots.
        slots = GetComponentsInChildren<Slot>().Select(s => s.transform).ToArray();

        foreach (Transform transf in slots)
        {
            if (transf.name == TipoPedacoSoftware) { 
            Image image = transf.GetChild(0).GetComponent<Image>();
            if (image.enabled == false)
            { //encontra primeiro slot desocupado, status de ocupado/desocupado do slot é definido pelo status do componente Image no filho, que sempre está presente.
                image.enabled = true;
                image.sprite = pedaco.sprite;


                //Troca o nome do objeto de Vazio para Tipo<numeroPedacoSoftware>. Ex: Tipo1
                transf.GetChild(0).name = TipoPedacoSoftware;
                //Colore com a cor do pedacoSoftware.
                switch (pedaco.color)
                {
                    case "red":
                        image.color = Color.red;
                        break;
                    case "green":
                        image.color = Color.green;
                        break;
                    case "yellow":
                        image.color = Color.yellow;
                        break;
                    case "blue":
                        image.color = Color.blue;
                        break;
                    case "gray":
                        image.color = Color.gray;
                        break;
                    case "purple":
                        image.color = new Color(0.29f, 0, 0.5f, 1f);
                        break;
                    case "black":
                        image.color = Color.black;
                        break;
                    default:
                        image.color = Color.clear;
                        break;
                }

                transf.GetChild(0).GetComponent<Image>().GetComponent<DragHandler>().pedacoDeSoftwareFisico = pedaco.gameObject;
                return 0;
            }
        }

		}
        //Se a função sair do foreach, significa que não há espaço para o pedacoSoftware. Retorna -1.
        return -1;
    }



}



namespace UnityEngine.EventSystems
{

    public interface IHasChanged : IEventSystemHandler
    {

        void HasChanged();

    }

}