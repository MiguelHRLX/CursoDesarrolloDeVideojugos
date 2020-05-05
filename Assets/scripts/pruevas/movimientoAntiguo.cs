using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoAntiguo : MonoBehaviour
{
    Rigidbody rb;
    public float fuerzaSalto = 10, aceleración = 10f, maxvel = 10, desaceleracion = 5f, velminima = 5f;
    bool dobleS;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dobleS = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velxz = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (rb.velocity.y == 0)
        {
            dobleS = false;
        }

        //saltar
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            Debug.Log("salto");
            rb.AddForce(Vector3.up * fuerzaSalto / Time.fixedDeltaTime);
            dobleS = true;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && dobleS == true)
        {
            Debug.Log("doble salto");
            rb.AddForce(Vector3.up * fuerzaSalto / Time.fixedDeltaTime);
            dobleS = false;
        }


        //movimiento en plano XZ
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * aceleración / Time.fixedDeltaTime);
        }



        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-Vector3.forward * aceleración / Time.fixedDeltaTime);
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * aceleración / Time.fixedDeltaTime);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-Vector3.right * aceleración / Time.fixedDeltaTime);
        }


        //mantener la velocidad constante en el plano xz

        if (velxz.magnitude >= maxvel)
        {
            rb.velocity = velxz.normalized * maxvel + new Vector3(0, rb.velocity.y, 0);
        }


        //desaceleración cuando se deja de precionar la tecla

        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            if (rb.velocity.x > velminima)
            {
                rb.AddForce(-Vector3.right * desaceleracion / Time.fixedDeltaTime);
            }
            else if (rb.velocity.x < -velminima)
            {
                rb.AddForce(Vector3.right * desaceleracion / Time.fixedDeltaTime);
            }
            else if (rb.velocity.x >= -velminima && rb.velocity.x <= velminima)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            }
        }


        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            if (rb.velocity.z > velminima)
            {
                rb.AddForce(-Vector3.forward * desaceleracion / Time.fixedDeltaTime);
            }
            else if (rb.velocity.z < -velminima)
            {
                rb.AddForce(Vector3.forward * desaceleracion / Time.fixedDeltaTime);
            }
            else if (rb.velocity.z >= -velminima && rb.velocity.z <= velminima)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            }
        }


        //cancelar velocidades cuando se precionana teclas opuestas
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            if (rb.velocity.x > velminima)
            {
                rb.AddForce(-Vector3.right * desaceleracion / Time.fixedDeltaTime);
            }
            else if (rb.velocity.x < -velminima)
            {
                rb.AddForce(Vector3.right * desaceleracion / Time.fixedDeltaTime);
            }
            else if (rb.velocity.x >= -velminima && rb.velocity.x <= velminima)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            }
        }


        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            if (rb.velocity.z > velminima)
            {
                rb.AddForce(-Vector3.forward * desaceleracion / Time.fixedDeltaTime);
            }
            else if (rb.velocity.z < -velminima)
            {
                rb.AddForce(Vector3.forward * desaceleracion / Time.fixedDeltaTime);
            }
            else if (rb.velocity.z >= -velminima && rb.velocity.z <= velminima)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        // Debug.Log(rb.velocity.magnitude);
    }
}
