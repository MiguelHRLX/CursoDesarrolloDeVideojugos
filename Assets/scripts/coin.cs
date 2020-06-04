using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class coin : MonoBehaviour
{
    public float velRot = 30f;
    public int value = 1;
    GameObject play,gmana;
    AudioSource au;

    // Start is called before the first frame update
    void Start()
    {
        au = gameObject.GetComponent<AudioSource>();
        gmana = GameObject.Find("gameManager");
        play = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0,velRot*Time.deltaTime,0), Space.World);
    }

    private void OnTriggerEnter(Collider ot)
    {
        if (ot.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            Destroy(gameObject,1f);
            au.Play();
            playerControler.PL.Puntaje(value);
        }
    }
}
