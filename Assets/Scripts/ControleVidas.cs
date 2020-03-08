using UnityEngine;
using System.Collections;

public class ControleVidas : MonoBehaviour {

    public int numVida = 3;
    public Animator animVida;
    public AlienScript alienScript;

	// Use this for initialization
	void Start () {
        mudaVida(0);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void mudaVida(int vida)
    {
        numVida += vida;

        if (numVida <= 0)
        {
            numVida = 0;
            alienScript.morre();

        }
        if (numVida >= 5)
        {
            numVida = 5;
        }

        
        switch (numVida)
        {
            case 0:
                animVida.Play("zeroVida");
                break;
            case 1:
                animVida.Play("umaVida");
                break;
            case 2:
                animVida.Play("duasVida");
                break;
            case 3:
                animVida.Play("tresVida");
                break;
            case 4:
                animVida.Play("quatroVida");
                break;
            case 5:
                animVida.Play("cincoVida");
                break;

        }
        
    }
}
