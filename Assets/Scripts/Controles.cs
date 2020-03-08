using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Controles : MonoBehaviour {


    public GameObject playpause;//7.5
    public GameObject som;//6.3
    public GameObject vibrar;//5.1

    

    public GameObject controle;

    private bool pausar = false;

    private bool clickConfig = false;

	// Use this for initialization
	void Start () {

        
    }

    

    private void mostraControles()
    {

        
        playpause.SetActive(true);
        playpause.transform.position = new Vector3(controle.transform.position.x , controle.transform.position.y + 2f, playpause.transform.position.z);//7.5
        if (pausar)
        {
            playpause.GetComponent<Animator>().Play("pause");
        }else
        {
            playpause.GetComponent<Animator>().Play("play");
        }

        /*som.SetActive(true);
        if (PlayerPrefs.GetString("som") != "nao")
        {
            som.GetComponent<Animator>().Play("somOn");
        }
        else
        {
            som.GetComponent<Animator>().Play("somOff");
        }
        som.transform.position = new Vector3(controle.transform.position.x, controle.transform.position.y + 3.2f, som.transform.position.z);//6.3
        */

        vibrar.SetActive(true);
        if (PlayerPrefs.GetString("vibrar") != "nao")
        {
            vibrar.GetComponent<Animator>().Play("vibraOn");
        }
        else
        {
            vibrar.GetComponent<Animator>().Play("vibraOff");
        }
        vibrar.transform.position = new Vector3(controle.transform.position.x, controle.transform.position.y + 3.2f, vibrar.transform.position.z);//5.1 // + 4.4f


        //fechar.SetActive(true);
        //fechar.transform.position = new Vector3(controle.transform.position.x, controle.transform.position.y + 5.6f, fechar.transform.position.z);//3.9

        clickConfig = true;
    }

    private void escondeControles()
    {
        playpause.SetActive(false);
        som.SetActive(false);
        vibrar.SetActive(false);
        //fechar.SetActive(false);
        clickConfig = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (pausar)
        {
            Time.timeScale = 0;
            
        }

        if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //Debug.Log ("Raycast: " + hit.collider.gameObject.tag);
            if (hit.collider != null)
            {

                if (hit.collider.gameObject.tag == "controle")
                {
                    if (!clickConfig)
                    {
                        mostraControles();
                    }else
                    {
                        escondeControles();
                    }
                }

                if (hit.collider.gameObject.tag == "fechar")
                {
                    Application.Quit();
                }

                if (hit.collider.gameObject.tag == "again")
                {
                    
                    SceneManager.LoadScene("principal");
                    Time.timeScale = 1;

                }

                if (hit.collider.gameObject.tag == "playpause")
                {
                    if (!pausar)
                    {
                        playpause.GetComponent<Animator>().Play("pause");
                        pausar = true;
                    }else
                    {
                        playpause.GetComponent<Animator>().Play("play");
                        pausar = false;
                        Time.timeScale = 1;
                    }
                    
                }

                if (hit.collider.gameObject.tag == "vibrar")
                {
                    if (PlayerPrefs.GetString("vibrar") != "nao")
                    {
                        PlayerPrefs.SetString("vibrar","nao");
                        vibrar.GetComponent<Animator>().Play("vibraOff");
                    }
                    else
                    {
                        PlayerPrefs.SetString("vibrar", "sim");
                        vibrar.GetComponent<Animator>().Play("vibraOn");
                    }
                }

                if (hit.collider.gameObject.tag == "som")
                {
                    if (PlayerPrefs.GetString("som") != "nao")
                    {
                        PlayerPrefs.SetString("som", "nao");
                        som.GetComponent<Animator>().Play("somOff");
                    }
                    else
                    {
                        PlayerPrefs.SetString("som", "sim");
                        som.GetComponent<Animator>().Play("somOn");
                    }
                }

            }
        }

    }

}
