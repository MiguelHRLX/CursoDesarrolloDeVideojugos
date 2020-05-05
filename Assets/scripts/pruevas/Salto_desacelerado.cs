using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto_desacelerado : MonoBehaviour
{
    [Header("Valores físicos para el jugador")]
    public float fuerza_salto = 20;
    public float vel_mov=20, vel_max=20,vrel,num_saltos=1;
   
    [Range(0f, 2f)]
    public float tiempo_desal=1;
    Vector3 new_gravity=Physics.gravity;

    [Range(1,20)] [Header("Gravedad")]
    public int escala_gravedad;

    [Header("Físicas en el acto")]
    public bool movUP;
    public bool movD, movL, movR;
    public bool desUP, desD, desL, desR;


    int i = 0;
    float vel_instZ1, vel_instZ2, vel_instX1, vel_instX2;
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

        //SALTO DOBLE
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (rbd.velocity.y == 0)
            {
                i = 0;
            }
            i++;
            if (i <= num_saltos)
            {
                rbd.AddForce(new Vector3(0, 1, 0) * fuerza_salto / Time.fixedDeltaTime);
                //rbd.AddForce(new Vector3(0, 1, 0) * fuerza_salto, ForceMode.Impulse);
                Debug.Log(i);
            }

        }


        //RECEPCION DE LOGICAS DE MOVIMIENTO
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movUP = true;
            desUP = false;
        }
        else movUP = false;

        if (Input.GetKey(KeyCode.DownArrow))
        {
            movD = true;
            desD = false; ;
        }
        else movD = false;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movR = true;
            desR = false;
        }
        else movR = false;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movL = true;
            desL = false;
        }
        else movL = false;

        //RECEPCION DE DESACELERACIÓN DE MOVIMIENTO
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            vel_instZ1 = rbd.velocity.z;
            desUP = true;
        }
        

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            vel_instZ2 = rbd.velocity.z;
            desD = true;
            
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            vel_instX1 = rbd.velocity.x;
            desR = true;
           
        }


        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            vel_instX2 = rbd.velocity.x;
            desL = true;
            
        }
        Debug.Log(Physics.gravity);
    }

    void FixedUpdate()
    {
        //CONTROL DE LA ESCALA DE LA GRAVEDAD
        Physics.gravity= new_gravity*escala_gravedad;
       
        //VELOCIDAD RELATIVA DEL CUERPO(MAGNITUD)
        vrel = rbd.velocity.magnitude;



        //FÍSICAS DE MOVIMIENTO
        if (movUP)
        {
            if (rbd.velocity.z < vel_max) rbd.AddForce(new Vector3(0, 0, 1) * vel_mov);
        }

        if (movD)
        {
            if (rbd.velocity.z > -vel_max) rbd.AddForce(new Vector3(0, 0, 1) * -vel_mov);
        }


        if (movR)
        {
            if (rbd.velocity.x < vel_max) rbd.AddForce(new Vector3(1, 0, 0) * vel_mov);
        }

        if (movL)
        {
            if (rbd.velocity.x > -vel_max) rbd.AddForce(new Vector3(1, 0, 0) * -vel_mov);
        }

        //FÍSICAS DE DESACELERACIÓN
        if (desUP)
        {

            if (rbd.velocity.z > 0.001) rbd.AddForce(new Vector3(0, 0, -vel_instZ1 / tiempo_desal),ForceMode.Acceleration);
            else
            {
                rbd.velocity = new Vector3(rbd.velocity.x, rbd.velocity.y, 0);
                desUP = false;
            }

        }

        if (desD)
        {
            if (rbd.velocity.z < -0.001) rbd.AddForce(new Vector3(0, 0, -vel_instZ2 / tiempo_desal), ForceMode.Acceleration);
            else
            {
                rbd.velocity = new Vector3(rbd.velocity.x, rbd.velocity.y, 0);
                desD = false;
            }
        }

        if (desR)
        {
            if (rbd.velocity.x > 0.001) rbd.AddForce(new Vector3(-vel_instX1 / tiempo_desal, 0, 0), ForceMode.Acceleration);
            else
            {
                rbd.velocity = new Vector3(0, rbd.velocity.y, rbd.velocity.z);
                desR = false;
            }
        }
        if (desL)
        {
            if (rbd.velocity.x < -0.001) rbd.AddForce(new Vector3(-vel_instX2 / tiempo_desal, 0, 0), ForceMode.Acceleration);
            else
            {
                rbd.velocity = new Vector3(0, rbd.velocity.y, rbd.velocity.z);
                desL = false;
            }
        }
    }
}
