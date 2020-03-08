using UnityEngine;
using System.Collections;

public class PisoScript : MonoBehaviour {
    private NaveScript naveScript;
    public GameObject Nave;
    public int velocidadeCamera = 2;
    public GameObject Explosao;
    public AudioClip explode;

    // Use this for initialization
    void Start () {
        naveScript = Nave.GetComponent<NaveScript>();
    }
	
	// Update is called once per frame
	void Update () {

        Explosao.transform.Translate(Vector2.up * Time.deltaTime * velocidadeCamera);

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "nave")
        {

            Explosao.transform.position = new Vector3(coll.gameObject.transform.position.x, coll.gameObject.transform.position.y, -2F);
            Explosao.GetComponent<Animator>().Play("explode");
            //AudioSource.PlayClipAtPoint(explode, transform.position, .4f);

            Destroy(coll.gameObject);
            naveScript.addNave();
        }

        if (coll.gameObject.tag == "coracao")
        {

            Destroy(coll.gameObject);

        }

        if (coll.gameObject.tag == "fundo")
        {
            Destroy(coll.gameObject);
        }


    }

}
