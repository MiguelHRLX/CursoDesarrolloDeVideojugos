using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class manager : MonoBehaviour
{
    public GameObject MainMenu,Controls;
    
    // Start is called before the first frame update
    private void Awake()
    {
       
    }
    void Start()
    {
        MainMenu.gameObject.SetActive(true);
        Controls.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
       
      
    }

    public void pasarAlJuego()
    {
        SceneManager.LoadScene(1);
    }
    public void verControles()
    {
      Controls.gameObject.SetActive(true);
      MainMenu.gameObject.SetActive(false);
    }   
    public void RegresarMenu()
    {
        MainMenu.gameObject.SetActive(true);
        Controls.gameObject.SetActive(false);
    }
    public void salir()
    {
        Application.Quit();
    }
}
