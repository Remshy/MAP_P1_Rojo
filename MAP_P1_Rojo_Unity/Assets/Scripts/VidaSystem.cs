using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VidaSystem : MonoBehaviour
{
    public int vida;
    public int vidaMaxima;

    public Image[] corazon;
  

    public Sprite lleno;
    public Sprite medio;
    public Sprite vacio;
    int scene;
    private void Awake()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        HealthLogic();
    }

    void HealthLogic()
    {

        if (vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }
        for (int i = 0; i < corazon.Length; i++)
        {
            if (i < vida)
            {
                corazon[i].sprite = lleno;
            }
          
            /* 
            {
                corazon[i].sprite = medio;
            }*/
          
            else
            {
                corazon[i].sprite = vacio;
            }

            if (i < vidaMaxima)
            {
                corazon[i].enabled = true;
            }
            else
            {
                corazon[i].enabled = false;
            }
            Debug.Log(vida);
        }

        if(vida == 0)
        {
            SceneManager.LoadScene(scene);
        }

    }
}
