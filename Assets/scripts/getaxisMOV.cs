using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getaxisMOV : MonoBehaviour
{
    Rigidbody rb;
    public float vel = 10f, fuerzaSalto = 20, Gscale = 1f, mulSalto = 1f;
    float x, z;
    public bool salto = false, dobleS = false, CanMove = true;
    public Vector3 g ;
    Vector3 velxz;
    

    // Start is called before the first frame update
    void Start()
    {
        g = Physics.gravity;
        mulSalto = 1f;
        rb = GetComponent<Rigidbody>();
       
        
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
        if (Input.GetKeyDown(KeyCode.Space) && salto == true&&CanMove==true)
        {
            rb.velocity = new Vector3(velxz.x, 0.01f, velxz.z);
            rb.AddForce(-Physics.gravity.normalized * fuerzaSalto * mulSalto / Time.fixedDeltaTime);
            dobleS = true;
            salto = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && dobleS == true&&CanMove==true)
        {
            rb.velocity = new Vector3(velxz.x, 0.01f, velxz.z);
            rb.AddForce(-Physics.gravity.normalized * fuerzaSalto * mulSalto / Time.fixedDeltaTime);
            dobleS = false;
        }

    
    }
    private void FixedUpdate()
    {

        rb.velocity = Vector3.ClampMagnitude(velxz, vel) + new Vector3(0, rb.velocity.y, 0);
    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("plataform")  ) 
        {
            salto = true;
            dobleS = false;
        }
    }
 
}
