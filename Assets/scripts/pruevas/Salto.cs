using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public float fuerzaJ, mov, vmax;
    public bool movUP,movD,movL,movR;
    int i = 0;
    Rigidbody rbd;
   

    // Start is called before the first frame update
    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
        
        //rbd=GetComponent<Rigidbody>();
        //rbd=this.GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (rbd.velocity.y == 0)
            {
                i = 0;
            }
            i++;
            if (i <= 2)
            {
                rbd.AddForce(new Vector3(0, 1, 0) * fuerzaJ / Time.fixedDeltaTime);
                Debug.Log(i);
            }

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movUP = true;

        }
        else movUP = false;

        if (Input.GetKey(KeyCode.DownArrow))
        {
            movD = true;
        }
        else movD = false;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movR = true;
        }
        else movR = false;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movL = true;
        }
        else movL = false;


        Debug.Log(rbd.velocity);



        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            rbd.velocity = new Vector3(rbd.velocity.x, rbd.velocity.y, 0f);
           
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            rbd.velocity = new Vector3(rbd.velocity.x, rbd.velocity.y, 0f);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rbd.velocity = new Vector3(0f, rbd.velocity.y, rbd.velocity.z);
        }


        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rbd.velocity = new Vector3(0f, rbd.velocity.y, rbd.velocity.z);
        }
    }

    void FixedUpdate()
    {
        

        if (movUP)
        {
            if(rbd.velocity.z<vmax) rbd.AddForce(new Vector3(0,0,1)*mov);
        }

        if (movD)
        {
            if (rbd.velocity.z> -vmax) rbd.AddForce(new Vector3(0, 0, 1) * -mov);
        }


        if (movR)
        {
            if (rbd.velocity.x < vmax) rbd.AddForce(new Vector3(1, 0, 0) * mov);
        }

        if (movL)
        {
            if (rbd.velocity.x > -vmax) rbd.AddForce(new Vector3(1, 0, 0) * -mov);
        }
        
    }
}
