using UnityEngine;
using System.Collections;

public class MoveAnimais : MonoBehaviour {

    public AlienScript alienScript;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * Time.deltaTime * 3);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "alien")
        {
            if (!alienScript.bateuAnimal) { 
                alienScript.muda("animal");
                //Debug.Log("bateu animal");
                if (!alienScript.bateu && PlayerPrefs.GetString("vibrar") != "nao")
                {
                    Handheld.Vibrate();
                }
            }
        }

    }
}
