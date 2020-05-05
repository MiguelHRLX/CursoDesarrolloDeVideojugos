using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class coin : MonoBehaviour
{
    public float velRot = 30f;
    public int value = 1;
    GameObject play;

    // Start is called before the first frame update
    void Start()
    {
        play = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0,velRot*Time.deltaTime,0), Space.World);
    }

    private void OnTriggerEnter(Collider ot)
    {
        if (ot.name==play.name)
        {
            Destroy(gameObject,0.1f);
            play.GetComponent<playerControler>().Puntaje(value);
        }
    }
}
