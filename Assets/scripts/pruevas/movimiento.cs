using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    Rigidbody rb;
    public float fuerzaSalto = 10, aceleración = 40f, maxvel = 15, desaceleracion = 90f, velminima = 8f, t = 0.1f, Gscale = 0.35f, tiempoSaltoSubida=1f;
    bool dobleS,salto,movR,movL,movF,movB;
    Vector3 velxz, g;


    // Start is called before the first frame update
    void Start()
    {
        g=Physics.gravity;
        rb = GetComponent<Rigidbody>();
        dobleS = false;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = g * Gscale;

        fuerzaSalto = Physics.gravity.magnitude*tiempoSaltoSubida;

       Debug.Log(Time.deltaTime + " " + rb.velocity.y);
       

        velxz = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        desaceleracion =velxz.magnitude/t;

        // Debug.Log(velxz.magnitude);
        if (rb.velocity.y == 0)
        {
            dobleS = false;
            salto = true;
        }
        
        //mantener la velocidad constante en el plano xz
        if (velxz.magnitude >= maxvel)
        {
            rb.velocity = velxz.normalized * maxvel + new Vector3(0, rb.velocity.y, 0);
        }

       

        //saltar
        if (Input.GetKeyDown(KeyCode.W) && salto ==true)
        {
            rb.velocity = velxz.normalized + new Vector3(0, 0.001f, 0); 
            rb.AddForce(Vector3.up * fuerzaSalto / Time.fixedDeltaTime);
            dobleS = true;
            salto = false;
        } else if (Input.GetKeyDown(KeyCode.W) && dobleS == true)
        {
           rb.velocity = velxz.normalized + new Vector3(0, 0.001f, 0); 
            rb.AddForce(Vector3.up * fuerzaSalto / Time.fixedDeltaTime);
            dobleS = false;
        }
     
        //flechas de movimiento en plano XZ

        if (Input.GetKey(KeyCode.UpArrow))
           movF = true;
        else  movF = false;

        if (Input.GetKey(KeyCode.DownArrow))
            movB = true;
        else  movB = false;

        if (Input.GetKey(KeyCode.RightArrow))
            movR = true;
        else  movR = false;

        if (Input.GetKey(KeyCode.LeftArrow))
            movL = true;
        else  movL = false; 
    }

    void FixedUpdate()
    { 
        //movimiento en plano XZ
        if (movF==true)
        rb.AddForce(Vector3.forward * aceleración);
        
        if (movB==true)
        rb.AddForce(-Vector3.forward * aceleración );

        if (movR==true)
        rb.AddForce(Vector3.right * aceleración );

        if (movL==true)
        rb.AddForce(-Vector3.right * aceleración );


        //desaceleración cuando se deja de precionar la tecla
    
        if (movR==false && movL==false)
        {
            if (rb.velocity.x > velminima)
            rb.AddForce(-Vector3.right * desaceleracion);

            else if (rb.velocity.x < -velminima)
            rb.AddForce(Vector3.right * desaceleracion);

            else if (rb.velocity.x >= -velminima && rb.velocity.x <= velminima)
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);  
        }

        if (movF == false && movB == false)
        {
            if (rb.velocity.z > velminima)
            rb.AddForce(-Vector3.forward * desaceleracion);
        
            else if (rb.velocity.z < -velminima)
            rb.AddForce(Vector3.forward * desaceleracion);
                
            else if (rb.velocity.z >= -velminima && rb.velocity.z <= velminima) 
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
        }

        //cancelar velocidades cuando se precionana teclas opuestas
        if (movR == true && movL == true)
        {
            if (rb.velocity.x > velminima)
            rb.AddForce(-Vector3.right * desaceleracion);
                
            else if (rb.velocity.x < -velminima)
            rb.AddForce(Vector3.right * desaceleracion);
             
            else if (rb.velocity.x >= -velminima && rb.velocity.x <= velminima)
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
           
        }

        if (movF == true && movB ==true)
        {
            if (rb.velocity.z > velminima)
            rb.AddForce(-Vector3.forward * desaceleracion);

            else if (rb.velocity.z < -velminima)
            rb.AddForce(Vector3.forward * desaceleracion);

            else if (rb.velocity.z >= -velminima && rb.velocity.z <= velminima)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
         
        }

    }



}
