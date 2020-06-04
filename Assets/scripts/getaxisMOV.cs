using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class getaxisMOV : MonoBehaviour
{//movimiento y físicas
    Rigidbody rb;
    public float vel = 10f, fuerzaSalto = 20, Gscale = 1f, mulSalto = 1f;
    float x, z;
    public bool salto = false, dobleS = false, CanMove = true;
    public Vector3 g ;
    Vector3 velxz;

    //controladores de efectos
    public Vector3 puntoAparicion;
    public bool daño = false, vid = false;
    public float tiempoDaño = 0.5f, tda = 0;
    playerControler Manag;

   

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        puntoAparicion = gameObject.transform.position;
        tda = 0;
        g = new Vector3(0,-9.81f,0) ;
        mulSalto = 1f;
        rb = GetComponent<Rigidbody>();

        //buscar el manager
        Manag = GameObject.Find("gameManager").GetComponent<playerControler>();
        
    }

    // Update is called once per frame
    void Update()
    {
       Physics.gravity = g * Gscale;

        if (CanMove==false)
        {
            x = 0;
            z = 0;
        }
        else {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }

        velxz = new Vector3(x*vel, 0, z*vel);


       // Debug.Log(rb.velocity);

        if (rb.velocity.y==0)
        {
           // Debug.Log(rb.velocity.y);
            salto =true;
            dobleS =false;
        }

        //saltar
        if (Input.GetKeyDown(KeyCode.R) && salto == true&&CanMove==true)
        {
            rb.velocity = new Vector3(velxz.x, 0.01f, velxz.z);
            rb.AddForce(-Physics.gravity.normalized * fuerzaSalto * mulSalto / Time.fixedDeltaTime);
            dobleS = true;
            salto = false;
        }
        else if (Input.GetKeyDown(KeyCode.R) && dobleS == true&&CanMove==true)
        {
            rb.velocity = new Vector3(velxz.x, 0.01f, velxz.z);
            rb.AddForce(-Physics.gravity.normalized * fuerzaSalto * mulSalto / Time.fixedDeltaTime);
            dobleS = false;
        }

//cosas de daño
        if (transform.position.y<=-20)
        {
            if (vid == true)
            {
                playerControler.PL.aumentoVida(-1);
            }
            hacerDaño();
        }


        if (daño)
        {
            tda = Time.time;
            daño = false;
        }
        else if (daño == false && CanMove == false&&playerControler.PL.vidas>0)
        {
            if (Time.time - tda >= tiempoDaño)
            {
                CanMove = true;
            }

        }
        if (playerControler.PL.vidas<=0)
        {
            CanMove = false;
        }
      

    }

    private void FixedUpdate()
    {

        rb.velocity = Vector3.ClampMagnitude(velxz, vel) + new Vector3(0, rb.velocity.y, 0);
    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("plataform"))
        {
            salto = true;
            dobleS = false;
        }


       //temas de daño y vida
        if (col.transform.CompareTag("peligro"))
        {
            if (vid == true)
            {
                playerControler.PL.aumentoVida(-1);
            }
            hacerDaño();
        }

        if (col.transform.CompareTag("plataform"))
        {
            gameObject.transform.parent = col.transform;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.transform.CompareTag("plataform"))
        {
            gameObject.transform.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("check"))
        {
            Debug.Log("checkpoint");
            other.GetComponent<Collider>().enabled = false;
            puntoAparicion = other.transform.position + Vector3.up;
        }
    }

    public void hacerDaño()
    {
        if (playerControler.PL.vidas >=0&& vid==true)
        {
            transform.position = puntoAparicion;
          //  Debug.Log("vidas " + Manag.vidas);
            daño = true;
            CanMove = false;
        }
    }

}
