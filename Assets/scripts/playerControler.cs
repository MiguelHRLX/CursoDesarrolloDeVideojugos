using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerControler : MonoBehaviour
{
    public static playerControler PL;
    public int puntos = 0, vMax = 5, vidas;
     Text score;
    Text tvida;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("monedas").GetComponent<Text>();
        tvida = GameObject.Find("vida").GetComponent<Text>();
        PL = this;
        vidas = vMax;
        score.text = "SCORE : " + puntos;
        tvida.text = "VIDAD : "+ vidas;
       // Debug.Log("mover con las flechas y saltar con la tecla 'R' ");
            
       // Debug.Log("vidas : " +vidas);
    
    }
    private void Update()
    {
        if (score==null)
        {
            score = GameObject.Find("monedas").GetComponent<Text>();
        }
        if (tvida==null)
        {
            tvida = GameObject.Find("vida").GetComponent<Text>();
        }


       
    }


    public void aumentoVida(int v)
    {
        if (tvida!=null)
        {
            vidas += v;
            tvida.text = "VIDAD : " + vidas;
        }
       
    }
    //se queda aquí
    public void Puntaje(int val)
    {
        if (score!=null)
        {
            puntos += val;
            // Debug.Log("puntos : " + puntos);
            score.text = "SCORE : " + puntos;
        }
        
    }

   
}
