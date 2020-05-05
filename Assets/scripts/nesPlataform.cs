using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TreeEditor;
using UnityEngine;

public class nesPlataform : MonoBehaviour
{
    public GameObject pla, pi, pf;
    Vector3 posinicia,des,mid;
    public float t=1,vel,di,espera=2f,c;
    bool moverse= true;
    // Start is called before the first frame update
    void Start()
    {
        di = 1;
        posinicia = pi.transform.position;
        mid = (pf.transform.position + pi.transform.position) / 2;
        des = (pf.transform.position - pi.transform.position) / 2;
        vel = des.magnitude / t;
        transform.position = pi.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distancia = gameObject.transform.position - mid;

        if (moverse){
            transform.position = Vector3.MoveTowards(transform.position, mid + des*di,vel*Time.deltaTime); ;
        }
        
        if (transform.position == mid + des * di)
        {
           
                if (moverse)
                {
                    c = Time.time;
                    moverse = false;
                   
                }else if (Time.time-c>=espera&& moverse==false)
                {
                    moverse = true;
                    c = 0;
                    di *= -1;
                }
               
                
            

        }

    }
}
