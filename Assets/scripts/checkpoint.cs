using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    GameObject[] checks;
    int  actual;
    bool encontrado = false;
    // Start is called before the first frame update
    void Start()
    {
        
        checks = GameObject.FindGameObjectsWithTag("check");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<checks.Length; i++){
            if (checks[i].GetComponent<Collider>().enabled==false)
            {
                if (encontrado==false)
                {
                    actual = i;
      
                    encontrado = true;
                }else if (encontrado==true&&checks[i]!=checks[actual])
                {
                    checks[actual].GetComponent<Collider>().enabled = true;
                    actual = i;
                }
               

               
            }
            
        }

       

    }
}
