using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Cueva : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    Vector3 position;
    int scene;
    public AudioSource clip;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D cueva)
    {
        if(scene == 2)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            clip.Stop();
            SceneManager.LoadScene(2);

           /* position = new Vector3(-2.88f, 0.62f, 0f);
            player.position = position;*/
        }
    }

}
