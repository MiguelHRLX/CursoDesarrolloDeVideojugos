using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class playerControler : MonoBehaviour
{
    public int puntos = 0, vMax = 5, vidas;
    public Vector3 puntoAparicion;
    public bool daño = false,vid=false;
    public float tiempoDaño = 0.5f,tda=0;
    getaxisMOV cm;
    // Start is called before the first frame update
    void Start()
    {
        vidas = vMax;
        tda = 0;
       // Debug.Log("mover con las flechas y saltar con la tecla 'R' ");
            
       // Debug.Log("vidas : " +vidas);
        cm = gameObject.transform.GetComponent<getaxisMOV>();
       
    }
    private void Update()
    {
        caerse();

        if (daño)
        {
            tda = Time.time;
            daño = false;
        }else if(daño==false &&cm.CanMove==false)
        {
            if (Time.time-tda>=tiempoDaño)
            {
                cm.CanMove = true;
            }

        }
        if (vidas<=0)
        {
           Physics.gravity= gameObject.GetComponent<getaxisMOV>().g;
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("peligro")){
            if (vid==true)
            {
                vidas -= 1;
            }
            HacerDaño();
        }

        if (col.transform.CompareTag("plataform"))
        {
            gameObject.transform.parent =col.transform;
        }

    }
    private void OnCollisionExit(Collision col)
    {
        if (col.transform.CompareTag("plataform"))
        {
            gameObject.transform.parent =null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("check"))
        {
            Debug.Log("checkpoint");
            other.GetComponent<Collider>().enabled = false;
            puntoAparicion = other.transform.position+Vector3.up;
        }
    }



    public void HacerDaño()
    {
        if (vidas>0) {
            transform.position = puntoAparicion;
            Debug.Log("vidas " + vidas);
            daño = true;
            cm.CanMove = false;
        }
    }

    public void Puntaje(int val)
    {
        puntos += val;
        Debug.Log("puntos : " + puntos);
    }

    public void caerse()
    {
        if (gameObject.transform.position.y<=-10){
            if (vid==true)
            {
                vidas -= 1;
            }
            HacerDaño();
        }
    }
}
