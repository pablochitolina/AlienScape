using UnityEngine;
using System.Collections;

public class GiraNaveScript : MonoBehaviour {
    private int velocidadeRoration = 100;
    public ControleVidas controleVidas;
    public AlienScript alienScript;

    // Use this for initialization
    void Start () {
	if(Random.Range(0,2) == 1)
        {
            velocidadeRoration *= -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0,0,1) * Time.deltaTime * velocidadeRoration);
	}
    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "alien")
        {
            if (!alienScript.bateu)
            {
                alienScript.muda("nave");
                //Debug.Log("bateu nave");
                controleVidas.mudaVida(-1);
                if (PlayerPrefs.GetString("vibrar") != "nao")
                {
                    Handheld.Vibrate();
                }
                
            }
        }

    }

    
}
