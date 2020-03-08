using UnityEngine;
using System.Collections;

public class AlienScript : MonoBehaviour
{

    public GameObject AlienDir;
    public GameObject AlienEsq;
    public GameObject AlienUp;
    public GameObject AlienDown;

    public int velocidadeCamera = 2;
    public int velocidadeAlien = 5;
    private bool limeteBaixo = false;
    private bool limeteLadoDir = false;
    private bool limeteLadoEsq = false;
    private bool limiteCima = false;

    private bool correDir = false;
    private bool correEsq = false;
    private bool correUp = false;
    private bool correDown = false;

    public GameObject setas;
    public GameObject colliders;

    public float tempoPisca = 1.5F;

    public bool bateu = false;

    private bool soltou = false;

    public bool bateuAnimal = false;

    public Animator setasUp;
    public Animator setasDir;
    public Animator setasEsq;
    public Animator setasDown;

    public Animator animAlienUp;
    public Animator animAlienDir;
    public Animator animAlienEsq;
    public Animator animAlienDown;

    private bool morreu = false;

    public string tipoAnimator = "";

    private float subTempo = 0;

    private Vector2 direcao;
    private int sentido;

    private GameObject AlienCorre;

    public GameObject distanciaPlaca;
    public GameObject fechaLateral;

    private float distancia = 0f;
    public TextMesh txtDistanciaAtual;

    public TextMesh txtDistanciaMaior;

    private float maiorDistancia = 0.0f;
    public GameObject morreMenu;

    public void morre()
    {
        morreu = true;
        Time.timeScale = 0;
        if(distancia > maiorDistancia)
        {
            PlayerPrefs.SetFloat("maiorDistancia", distancia);
            txtDistanciaMaior.text = distancia.ToString("0.00") + " M";
        }else
        {
            txtDistanciaMaior.text = maiorDistancia.ToString("0.00") + " M";
        }


        fechaLateral.SetActive(false);
        setas.SetActive(false);
       // distanciaPlaca.SetActive(false);
        morreMenu.SetActive(true);
    }

    // Use this for initialization
    void Start()
    {
        morreMenu.SetActive(false);
        maiorDistancia = PlayerPrefs.GetFloat("maiorDistancia");

        AlienDir.SetActive(false);
        AlienEsq.SetActive(false);
        AlienDown.SetActive(false);
        direcao = Vector2.zero;
        AlienCorre = AlienUp;

    }

    public void muda(string tipo)
    {
        if (!bateu) {

            tipoAnimator = "Pisca";

            if (tipo == "nave")
            {
                bateu = true;
                subTempo = 0;
                paraAnim();
            }
            else if(tipo == "animal")
            {
                bateuAnimal = true;
                subTempo = 0.75f;
                paraAnim();
            }

            StartCoroutine("mudaTipoAnimator");
        }

    }


    IEnumerator mudaTipoAnimator()
    {
  
        yield return new WaitForSeconds(tempoPisca);
        bateuAnimal = false;
        tipoAnimator = "";
        paraAnim();
        StartCoroutine("espera");

    }

    IEnumerator espera()
    {

        yield return new WaitForSeconds(0.1F);
        bateu = false;

    }

    private void mudaAnim()
    {

        if (correDir)
        {
            animAlienDir.Play("correDir" + tipoAnimator);
        }

        if (correEsq)
        {
            animAlienEsq.Play("correEsq" + tipoAnimator);
        }

        if (correUp)
        {
            animAlienUp.Play("correUp" + tipoAnimator);
        }

        if (correDown)
        {
            animAlienDown.Play("correDown" + tipoAnimator);

        }

    }


    private RaycastHit2D hit;
    //private Vector2 posAlien;
    //private bool travarSetas = false;

    // Update is called once per frame
    void Update()
    {

      /* if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if(hit.collider.tag == "up" || hit.collider.tag == "dir" || hit.collider.tag == "esq" || hit.collider.tag == "down")
                {
                    posAlien = new Vector2(AlienCorre.transform.position.x, AlienCorre.transform.position.y);
                    travarSetas = true;
                    setas.SetActive(travarSetas);

                }

            }
               
        }*/

        if(AlienCorre.transform.position.y > distancia)
        {
            distancia = AlienCorre.transform.position.y;

            txtDistanciaAtual.text = distancia.ToString("0.00") + " M";
        }

        if (Input.GetButton("Fire1") || Input.GetMouseButton(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //Debug.Log ("Raycast: " + hit.collider.gameObject.tag);
            if (hit.collider != null && !bateuAnimal)
            {
                if (hit.collider.tag == "up" && !morreu)// && !boolDown)
                {
                    
                    soltou = false;
                    if (AlienCorre.transform.position.y > Camera.main.transform.position.y + 10)
                    {
                        limiteCima = true;

                    }
                    else
                    {
                        /*if (mudaSeta)
                        {
                            setas.transform.position = new Vector3(posClick.x, posClick.y - 1, -5f);
                            mudaSeta = false;
                        }*/

                        DefineDir(false, false, true, false, false);
                        direcao = Vector2.up;
                        AlienUp.transform.position = AlienCorre.transform.position;
                        AlienCorre = AlienUp;
                        limeteBaixo = false;
                        limeteLadoDir = false;
                        limeteLadoEsq = false;
                        AlienCorre.transform.Translate(Vector2.up * Time.deltaTime * (velocidadeCamera));
                        animAlienUp.Play("correUp" + tipoAnimator);
                        setasUp.Play("pressUp");
                        setasDown.Play("notPressDown");
                        setasDir.Play("notPressDir");
                        setasEsq.Play("notPressEsq");
                        Corre();
                    }
                }

                if (hit.collider.tag == "dir" && !morreu)//&& !boolEsq)
                {
                    soltou = false;
                    if (AlienCorre.transform.position.x < Camera.main.transform.position.x + 5.5)
                    {

                        /*if (mudaSeta)
                        {
                            setas.transform.position = new Vector3(posClick.x -1, posClick.y, -5f);
                            mudaSeta = false;
                        }*/

                        DefineDir(true, false, false, false, false);
                        direcao = Vector2.right;
                        AlienDir.transform.position = AlienCorre.transform.position;
                        AlienCorre = AlienDir;
                        limeteLadoEsq = false;
                        limeteBaixo = false;
                        limiteCima = false;
                        animAlienDir.Play("correDir" + tipoAnimator);
                        setasUp.Play("notPressUp");
                        setasDown.Play("notPressDown");
                        setasDir.Play("pressDir");
                        setasEsq.Play("notPressEsq");
                        Corre();
                    }
                    else
                    {
                        limeteLadoDir = true;
                        correDir = false;
                        correEsq = false;
                        correCima();
                    }
                }
                if (hit.collider.tag == "esq" && !morreu)//&& !boolDir)
                {
                    soltou = false;
                    if (AlienCorre.transform.position.x > Camera.main.transform.position.x - 5.5)
                    {

                        /*if (mudaSeta)
                        {
                            setas.transform.position = new Vector3(posClick.x + 1, posClick.y, -5f);
                            mudaSeta = false;
                        }*/

                        DefineDir(false, true, false, false, false);
                        direcao = Vector2.left;
                        AlienEsq.transform.position = AlienCorre.transform.position;
                        AlienCorre = AlienEsq;
                        limeteLadoDir = false;
                        limeteBaixo = false;
                        limiteCima = false;
                        animAlienEsq.Play("correEsq" + tipoAnimator);
                        setasUp.Play("notPressUp");
                        setasDown.Play("notPressDown");
                        setasDir.Play("notPressDir");
                        setasEsq.Play("pressEsq");
                        Corre();
                    }
                    else
                    {
                        limeteLadoEsq = true;
                        correDir = false;
                        correEsq = false;
                        correCima();
                    }
                }

                if (hit.collider.tag == "down" && !morreu)// && !boolUp)
                {
                    soltou = false;
                    if (AlienCorre.transform.position.y < Camera.main.transform.position.y - 4)
                    {
                        limeteBaixo = true;
                        correCima();

                    }
                    else
                    {

                        /*if (mudaSeta)
                        {
                            setas.transform.position = new Vector3(posClick.x, posClick.y + 1, -5f);
                            mudaSeta = false;
                        }*/

                        DefineDir(false, false, false, true, false);
                        direcao = Vector2.down;
                        AlienDown.transform.position = AlienCorre.transform.position;
                        AlienCorre = AlienDown;
                        limiteCima = false;
                        limeteLadoDir = false;
                        limeteLadoEsq = false;
                        animAlienDown.Play("correDown" + tipoAnimator);
                        setasUp.Play("notPressUp");
                        setasDown.Play("pressDown");
                        setasDir.Play("notPressDir");
                        setasEsq.Play("notPressEsq");
                        Corre();
                    }
                }

            }
            else
            {
                if (!soltou)
                {
                    soltou = true;
                    correDir = false;
                    correEsq = false;
                    paraAnim();
                }
                

            }

        }

        if (AlienCorre.transform.position.y < Camera.main.transform.position.y - 4 )
        {

            AlienCorre.transform.Translate(Vector2.up * Time.deltaTime * velocidadeCamera);
            limeteBaixo = true;
            if (!correDir && !correEsq)
            {
                correCima();
            }

        }

        if (Input.GetButtonUp("Fire1") || Input.GetMouseButtonUp(0))
        {
            correDir = false;
            correEsq = false;
            //travarSetas = false;
            //setas.SetActive(travarSetas);


            paraAnim();

        }
        

        Camera.main.transform.Translate(Vector2.up * Time.deltaTime * velocidadeCamera);

       /* if (!travarSetas)
        {


            setas.transform.position = new Vector3(AlienCorre.transform.position.x, AlienCorre.transform.position.y, setas.transform.position.z);
            colliders.transform.position = new Vector3(AlienCorre.transform.position.x, AlienCorre.transform.position.y, colliders.transform.position.z);
            
        }else
        {
            if (setas.transform.position.y < Camera.main.transform.position.y - 4)
            {
                setas.transform.Translate(Vector2.up * Time.deltaTime * velocidadeCamera);
                colliders.transform.Translate(Vector2.up * Time.deltaTime * velocidadeCamera);

            }
        }
        */

    }

    private void paraAnim()
    {

        animAlienUp.Play("paradoUp" + tipoAnimator);
        setasUp.Play("notPressUp");
        animAlienDir.Play("paradoDir" + tipoAnimator);
        setasDir.Play("notPressDir");
        animAlienEsq.Play("paradoEsq" + tipoAnimator);
        setasEsq.Play("notPressEsq");
        animAlienDown.Play("paradoDown" + tipoAnimator);
        setasDown.Play("notPressDown");
        limiteCima = false;

    }

    private void Corre()
    {
        if (!limeteBaixo && !limeteLadoDir && !limeteLadoEsq && !limiteCima)
        {
            AlienCorre.transform.Translate(direcao * Time.deltaTime * velocidadeAlien);
           
        }
        if (limiteCima)
        {
            AlienCorre.transform.Translate(Vector2.up * Time.deltaTime * (velocidadeCamera));
           

        }

    }

    private void correCima()
    {

        AlienCorre.transform.Translate(Vector2.up * Time.deltaTime * velocidadeCamera);
       
        DefineDir(false, false, true, false, false);
        direcao = Vector2.up;
        AlienUp.transform.position = AlienCorre.transform.position;
        AlienCorre = AlienUp;
        limeteBaixo = false;
        limeteLadoDir = false;
        limeteLadoEsq = false;
        animAlienUp.Play("correUp" + tipoAnimator);

        //animAlienUp.Play("paradoUp");
        setasUp.Play("notPressUp");
        //animAlienDir.Play("paradoDir");
        setasDir.Play("notPressDir");
        //animAlienEsq.Play("paradoEsq");
        setasEsq.Play("notPressEsq");
        //animAlienDown.Play("paradoDown");
        setasDown.Play("notPressDown");

    }

    private void DefineDir(bool dir, bool esq, bool up, bool down, bool stop)
    {

        correDir = dir;
        correEsq = esq;
        correUp = up;
        correDown = down;
        AlienDir.SetActive(dir);
        AlienEsq.SetActive(esq);
        AlienUp.SetActive(up);
        AlienDown.SetActive(down);

    }

    void OnTriggerEnter2D(Collider2D coll)
    {

      
            Debug.Log(coll.gameObject.tag);
        

    }
}
