using UnityEngine;
using System.Collections;

public class ControlCoracao : MonoBehaviour {

    public ControleVidas controleVidas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "alien")
        {

            controleVidas.mudaVida(1);

            Destroy(this.gameObject);

        }

    }
}
