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

	public void AdicionaTipoDeSoftware(pedacoSoftware pedaco) {
        Debug.Log(pedaco.color);
        foreach (Transform transf in slots) {
			
			Image image = transf.GetChild(0).GetComponent<Image>();
			if (image.enabled == false) { //encontra primeiro slot desocupado, status de ocupado/desocupado do slot é definido pelo status do componente Image no filho, que sempre está presente.
				image.enabled = true;
				image.sprite = pedaco.sprite;

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
				return;
			}
		}
	}

}



namespace UnityEngine.EventSystems
{

    public interface IHasChanged : IEventSystemHandler
    {

        void HasChanged();

    }

}