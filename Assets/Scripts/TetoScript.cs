using UnityEngine;
using System.Collections;

public class TetoScript : MonoBehaviour {

    // Use this for initialization
    private NaveScript naveScript;
    public GameObject Nave;

	void Start () {
        naveScript = Nave.GetComponent<NaveScript>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "novaNave")
        {
            //naveScript.addNave();
        }

    }
}
