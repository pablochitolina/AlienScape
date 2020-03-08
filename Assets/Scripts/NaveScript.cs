using UnityEngine;
using System.Collections;

public class NaveScript : MonoBehaviour {

    public GameObject NaveAzul;
    public GameObject NaveAmarelo;
    public GameObject NaveRosa;
    public GameObject NaveVerde;
    public GameObject NaveMarrom;
    private GameObject naveInstance;
    int posY = 104;
    float[] arrayPosX = {-5.5f, -5, -4.5f, -4, -3.5f -3, -2.5f, -2, 1.5f -1, -0.5f, 0, 0.5f, 1, 1.5f, 2, 2.5f, 3, 3.5f, 4, 4.5f, 5, 5.5f };
    int lastIndex = 0;
    int index = 0;
    int intervaloNave = 4;
    int numNaves = 6;
    int fundo = 2;
    int animal = 2;

    public GameObject bush;
    public GameObject bush1;
    public GameObject cactus;
    public GameObject plant;
    public GameObject cogu1;
    public GameObject cogu2;
    public GameObject cogu3;
    public GameObject cogu4;
    public GameObject cogu5;
    public GameObject cogu6;
    public GameObject pedra1;
    public GameObject pedra2;
    public GameObject terra;

    public GameObject Sapo;
    public GameObject Abelha;
    public GameObject Mosca;
    public GameObject Inseto;
    public GameObject Lesma;
    public GameObject Aranha;
    public GameObject Rato;

    private int ultimoCoracao = 0;
    private int intervaloCoracao = 20;

    public GameObject coracao;
    private GameObject coracaoInstance;

    private GameObject naveInstanceFundo;
    private GameObject animalInstance;

    // Use this for initialization
    void Start () {

        for (int i = 0; i <= posY; i+= intervaloNave)
        {
            addNave();
        }
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    public void addNave()
    {

        if (numNaves < 100)
        {
            intervaloNave = 3;
        }else
        {
            intervaloNave = 2;
            fundo++;
        }
        
        criaNave();

        if (numNaves >= 150) //150
        {
            criaAnimal();
        }


        if (fundo % 2 == 0)
        {
            criaFundo();
        }

        

        //Debug.Log("intervaloNave: " + intervaloNave + " - numNaves: " + numNaves + " - animal: " + animal + " - fundo: " + fundo);

    }
    private void criaCoracao()
    {


        coracaoInstance = Instantiate(coracao);
        while (true)
        {
            index = (int)Random.Range(0, arrayPosX.Length);
            if (index > lastIndex && index - lastIndex > 2 || index < lastIndex && lastIndex - index > 2)
            {
                break;
            }
        }

        //coracaoInstance.transform.position = new Vector3(arrayPosX[index], numNaves, 6);
        coracaoInstance.transform.position = new Vector3(arrayPosX[index], numNaves, 6);

    }

    private void criaNave()
    {

        GameObject Nave;
        switch (Random.Range(0, 5))
        {
            case 0:
                Nave = NaveAzul;
                break;
            case 1:
                Nave = NaveAmarelo;
                break;
            case 2:
                Nave = NaveVerde;
                break;
            case 3:
                Nave = NaveRosa;
                break;
            default:
                Nave = NaveMarrom;
                break;
        }

        numNaves += intervaloNave;
        
        while (true)
        {
            index = (int)Random.Range(0, arrayPosX.Length);
            if (index > lastIndex && index - lastIndex > 2 || index < lastIndex && lastIndex - index > 2)
            {
                break;
            }
        }
        lastIndex = index;
        naveInstance = Instantiate(Nave);
        naveInstance.transform.position = new Vector3(arrayPosX[index], numNaves, 0);
        naveInstance.transform.GetChild(0).transform.Rotate(new Vector3(0, 0, naveInstance.transform.rotation.y + Random.Range(0, 360)));

        ultimoCoracao++;
        if (Random.Range(0, 7) == Random.Range(0, 7) && ultimoCoracao > intervaloCoracao)
        {
            ultimoCoracao = 0;
            criaCoracao();
        }

    }

    private void criaAnimal()
    {

        if (Random.Range(0, 4) == 0)
        {
            switch (Random.Range(0, 7))
            {
                case 0:
                    animalInstance = Instantiate(Sapo);
                    break;
                case 1:
                    animalInstance = Instantiate(Abelha);
                    break;
                case 2:
                    animalInstance = Instantiate(Mosca);
                    break;
                case 3:
                    animalInstance = Instantiate(Inseto);
                    break;
                case 4:
                    animalInstance = Instantiate(Lesma);
                    break;
                case 5:
                    animalInstance = Instantiate(Aranha);
                    break;
                default:
                    animalInstance = Instantiate(Rato);
                    break;
            }

            switch (Random.Range(0, 3))
            {
                case 0:
                    animalInstance.transform.position = new Vector3(7, Camera.main.transform.position.y + Random.Range(0, 10), 8);
                    break;
                case 1:
                    animalInstance.transform.Rotate(new Vector3(0, 180, 0));
                    animalInstance.transform.position = new Vector3(-7, Camera.main.transform.position.y + Random.Range(0, 10), 8);
                    break;
                default:
                    switch (Random.Range(0, 3))
                    {
                        case 1:
                            animalInstance.transform.Rotate(new Vector3(0, 0, 90));
                            break;
                        default:
                            animalInstance.transform.Rotate(new Vector3(0, 180, 90));
                            break;
                    }
                    animalInstance.transform.position = new Vector3(arrayPosX[index], Camera.main.transform.position.y + 10, 8);

                    break;
            }

            Destroy(animalInstance, 10f);

        }

    }

    private void criaFundo()
    {

 
            switch (Random.Range(0, 12))
            {
                case 0:
                    naveInstanceFundo = Instantiate(bush);
                    break;
                case 1:
                    naveInstanceFundo = Instantiate(cactus);
                    break;
                case 2:
                    naveInstanceFundo = Instantiate(plant);
                    break;
                case 3:
                    naveInstanceFundo = Instantiate(cogu1);
                    break;
                case 4:
                    naveInstanceFundo = Instantiate(cogu2);
                    break;
                case 5:
                    naveInstanceFundo = Instantiate(cogu3);
                    break;
                case 6:
                    naveInstanceFundo = Instantiate(cogu4);
                    break;
                case 7:
                    naveInstanceFundo = Instantiate(cogu5);
                    break;
                case 8:
                    naveInstanceFundo = Instantiate(cogu6);
                    break;
                case 9:
                    naveInstanceFundo = Instantiate(pedra1);
                    break;
                case 10:
                    naveInstanceFundo = Instantiate(pedra2);
                    break;
                default:
                    naveInstanceFundo = Instantiate(bush1);
                    break;
            }


            lastIndex = index;
            while (true)
            {
                index = (int)Random.Range(0, arrayPosX.Length);
                if (index > lastIndex && index - lastIndex > 2 || index < lastIndex && lastIndex - index > 2)
                {
                    break;
                }
            }

            naveInstanceFundo.transform.position = new Vector3(arrayPosX[index], numNaves, 10);


    }
}
