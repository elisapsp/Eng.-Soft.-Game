using UnityEngine;
using System.Collections;

public class usaRecursos : MonoBehaviour {

    private GameObject inventario;

    private GameObject recursos;
    private GameObject player;
    private Player playerScript;
    

    private int nivelDebug;
    public GameObject Tiro1;
    public GameObject Tiro2;
    public float tempoRecargaArma = 0.2f;
    private float tempoRecargaCorrenteArma;

    private float tempoUsoPraticasMotivacionais;
    private bool usandoPraticasMotivacionais;
    public float velocidadePraticasMotivacionais = 0f;

    private float tempoUsoCafe;
    private bool usandoCafe;
    public float velocidadeCafe = 0f;

    public float forcaAumentoSalario = 0f;
    private bool usandoAumentoSalario;
    private float tempoUsoAumentoSalario;

    public GameObject controleVersao;

    public float duracaoRecursos = 3.0f;
    

    // Use this for initialization
    void Start () {

        player = gameObject.GetComponentInParent<Transform>().transform.gameObject;
        playerScript = player.GetComponent<Player>();
        recursos = GameObject.Find("Main Camera/GerenciarTime");
        inventario = GameObject.Find("Canvas/Inventario");

    }
	
	// Update is called once per frame
	void Update () {
	
	}


    
    //Pulo Duplo
    public void TreinamentoSCRUM()
    {

        if (recursos.GetComponent<Recursos>().ConhecimentoSCRUM == true)
        {
            playerScript.maxJumps = 2;
        }
        else
        {
            playerScript.maxJumps = 1;
        }

    }

    //Tiros
    public void ArmaDebugger()
    {
        nivelDebug = recursos.GetComponent<Recursos>().nivelDebug;
        tempoRecargaCorrenteArma += Time.deltaTime;

        if (tempoRecargaCorrenteArma >= tempoRecargaArma)
        {
            tempoRecargaCorrenteArma = tempoRecargaArma;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {


            if (tempoRecargaCorrenteArma >= tempoRecargaArma)
            {

                if (nivelDebug == 1)
                {
                    //Cria Tiro1
                    Instantiate(Tiro1, transform.position, Tiro1.transform.rotation);

                }
                else if (nivelDebug == 2)
                {
                    //Cria tiro2.
                    Instantiate(Tiro2, transform.position, Tiro2.transform.rotation);
                }
                else
                {
                    Debug.Log("Você precisa melhorar seu nível de Debug para ser utilizado desta forma.");
                }

                tempoRecargaCorrenteArma = 0f;
            }


        }
    }

    public void usoPraticasMotivacionais()
    {
        tempoUsoPraticasMotivacionais += Time.deltaTime;

        //Se estiver carregado pronto para uso.
        if (tempoUsoPraticasMotivacionais >= duracaoRecursos)
        {
            //Se já estiver usando (significa que acabou o tempo de uso).
            if (usandoPraticasMotivacionais == true)
            {
                //Seta usando == false.
                usandoPraticasMotivacionais = false;
                //Coloca a velocidade em 0.
                velocidadePraticasMotivacionais = 0f;
                //Deixa pronto para usar novamente.
                tempoUsoPraticasMotivacionais = duracaoRecursos;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && usandoPraticasMotivacionais == false)
        {
            if (recursos.GetComponent<Recursos>().PraticasMotivacionais > 0)
            {
                if (tempoUsoPraticasMotivacionais >= duracaoRecursos)
                {


                    velocidadePraticasMotivacionais = 1.0f;
                    usandoPraticasMotivacionais = true;
                    //Consome o recurso.
                    recursos.GetComponent<Recursos>().PraticasMotivacionais--;
                }

            }
            else
            {
                Debug.Log("Não há mais recursos para PraticasMotivacionais.");
            }
            tempoUsoPraticasMotivacionais = 0f;
        }

    }

    public void usoCafe()
    {
        tempoUsoCafe += Time.deltaTime;

        //Se estiver carregado pronto para uso.
        if (tempoUsoCafe >= duracaoRecursos)
        {
            //Se já estiver usando (significa que acabou o tempo de uso).
            if (usandoCafe == true)
            {
                //Seta usando == false.
                usandoCafe = false;
                //Coloca a velocidade em 0.
                velocidadeCafe = 0f;
                //Deixa pronto para usar novamente.
                tempoUsoCafe = duracaoRecursos;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && usandoCafe == false)
        {
            if (recursos.GetComponent<Recursos>().Cafe > 0)
            {
                if (tempoUsoCafe >= duracaoRecursos)
                {


                    velocidadeCafe = 1.0f;
                    usandoCafe = true;
                    //Consome o recurso.
                    recursos.GetComponent<Recursos>().Cafe--;
                }

            }
            else
            {
                Debug.Log("Não há mais Café.");
            }
            tempoUsoCafe = 0f;
        }

    }

    public void usoAumentoSalario()
    {
        tempoUsoAumentoSalario += Time.deltaTime;

        //Se estiver carregado pronto para uso.
        if (tempoUsoAumentoSalario >= duracaoRecursos)
        {
            //Se já estiver usando (significa que acabou o tempo de uso).
            if (usandoAumentoSalario == true)
            {
                //Seta usando == false.
                usandoAumentoSalario = false;
                //Coloca a forca adicional em 0.
                forcaAumentoSalario = 0f;
                //Deixa pronto para usar novamente.
                tempoUsoAumentoSalario = duracaoRecursos;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && usandoAumentoSalario == false)
        {
            if (recursos.GetComponent<Recursos>().aumentoSalario > 0)
            {
                if (tempoUsoAumentoSalario >= duracaoRecursos)
                {


                    forcaAumentoSalario = 100f;
                    usandoAumentoSalario = true;
                    //Consome o recurso.
                    recursos.GetComponent<Recursos>().aumentoSalario--;
                }

            }
            else
            {
                Debug.Log("Não há recursos para aumento de salário.");
            }
            tempoUsoAumentoSalario = 0f;
        }
    }


    public void colocarControleVersao()
    {
        //Colocar eles dentro de um único objeto chamado GitHub?


        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (recursos.GetComponent<Recursos>().controleVersao > 0)
            {
                Instantiate(controleVersao, transform.position, controleVersao.transform.rotation);
                recursos.GetComponent<Recursos>().controleVersao--;
            }
            else
            {
                Debug.Log("Não é mais possivel fazer mais commit das versões.");
            }
        }
    }

    public void aumentaInventarioDesenvolvedores()
    {
        if (recursos.GetComponent<Recursos>().desenvolvedores >= 0)
        {
            inventario.transform.FindChild("Linha1").gameObject.SetActive(true);

            if (recursos.GetComponent<Recursos>().desenvolvedores >= 1)
            {
                inventario.transform.FindChild("Linha2").gameObject.SetActive(true);

                if (recursos.GetComponent<Recursos>().desenvolvedores >= 2)
                {
                    inventario.transform.FindChild("Linha3").gameObject.SetActive(true);

                    if (recursos.GetComponent<Recursos>().desenvolvedores >= 3)
                    {
                        inventario.transform.FindChild("Linha4").gameObject.SetActive(true);
                    }

                }

            }

        }

    }

    public void TestaPedacosSoftware()
    {
        //Isso deve mudar depois. Ao invés de apertar T, o jogador terá que apertar o botão que estará disponível para testar código.
        if (Input.GetKeyDown("t"))
        {

            inventario.GetComponent<Inventory>().testaPedacosSoftware(recursos.GetComponent<Recursos>().testador);
        }
    }

}
