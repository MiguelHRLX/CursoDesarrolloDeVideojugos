using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaTrampa : MonoBehaviour
{
    public  Material peligro;
    Material ini;
    Collider co;
    bool sobre=false,cae=false;
    float t,Tcaida;
    public float v=10,tEspera=1.5f,TCaida=3;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        ini = gameObject.GetComponent<MeshRenderer>().material;
        pos = transform.position;
        co = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sobre==true)
        {
            t = Time.time;
            gameObject.GetComponent<MeshRenderer>().material = peligro;
            sobre = false;
           // Debug.Log("sobre plataforma");
        }

     
        if (Time.time - t >= tEspera&& t != 0)
        {
            Debug.Log("empesando a caer");
            co.enabled = false;
            cae = true;

        }

        if (cae==true)
        {
           // Debug.Log("caer");
            transform.Translate(Vector3.down * v * Time.deltaTime);
            if (Time.time-t>=tEspera+TCaida) {
               // Debug.Log("reinicio");
                t = 0;
                cae = false;
                transform.position = pos;
                gameObject.GetComponent<MeshRenderer>().material = ini;
                
                sobre = false;
                co.enabled = true;
            }
         }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Player")&& gameObject.GetComponent<MeshRenderer>().material != peligro)
        {
            sobre = true;
        }
    }
}
