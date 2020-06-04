using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameMenu : MonoBehaviour
{
    public int escene = 1;
    public static  gameMenu gm;
    public GameObject Muerte;
   public  GameObject game;
    public GameObject pausaMenu;
   public GameObject controlG;
    // Start is called before the first frame update
  
  

    void Start()
    {
        game.SetActive(true);
        pausaMenu.SetActive(false);
        controlG.SetActive(false);
        Muerte.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&Time.timeScale!=0)
        {
            game.SetActive(false);
            pausaMenu.SetActive(true);
            controlG.SetActive(false);
            Time.timeScale = 0;
        }

        if (playerControler.PL.vidas<=0)
        {
            muerteee();
        }
    }

  
    public void resume()
    {
        game.SetActive(true);
        pausaMenu.SetActive(false);
        controlG.SetActive(false);
        Time.timeScale = 1;
    }
    public void IrControles()
    {
        game.SetActive(false);
        pausaMenu.SetActive(false);
        controlG.SetActive(true);
    }
    public void regresarMenuPausa()
    {
        game.SetActive(false);
        pausaMenu.SetActive(true);
        controlG.SetActive(false);
    }
    public void irAlInicio()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void muerteee()
    {
        Time.timeScale = 0;
        Muerte.SetActive(true);
        game.SetActive(false);
        pausaMenu.SetActive(false);
        controlG.SetActive(false);
        
    }
    public void ResetLevel()
    {
        
        SceneManager.LoadScene(escene);
        

    }
    public void completeLevel()
    {

    }
}
