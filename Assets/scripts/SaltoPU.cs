using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoPU : MonoBehaviour
{   public float t,mul,rot=90f;
    MeshRenderer m;
    GameObject player;
    Collider c;

    // Start is called before the first frame update
    void Start()
    {
        m = GetComponent<MeshRenderer>();
        c = gameObject.GetComponent<Collider>();
        m.enabled =true;
        c.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(0, rot*Time.deltaTime, 0),Space.Self); 

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            getaxisMOV mm=other.GetComponent<getaxisMOV>();
            mm.mulSalto = mul;
            StartCoroutine(DesaparecerTem(mm));
          
        }
    }

    IEnumerator DesaparecerTem(getaxisMOV g)
    {
        Debug.Log("Tienes doble salto por "+t+" segundos");
        m.enabled = false;
        c.enabled = false;
        yield return new WaitForSeconds(t);
        m.enabled = true;
        c.enabled = true;
        g.mulSalto = 1f;
        Debug.Log("acabó doble salto");
    }

}
