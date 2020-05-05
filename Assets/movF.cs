using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movF : MonoBehaviour
{
    public Rigidbody rb;
    public float acel = 5;
    public float maxvel=5;
    bool llego = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
   void FixedUpdate()
    {
        Debug.Log(rb.velocity);
        if (rb.velocity.magnitude<maxvel &&llego ==false)
        {
            rb.AddForce(new Vector3(acel,0f,0f));
        }
        else
        {
            //rb.AddForce(new Vector3(-acel, 0f, 0f));
            llego = true;
            rb.velocity = new Vector3(0,0,0);       
        }
   
    }

    
}
