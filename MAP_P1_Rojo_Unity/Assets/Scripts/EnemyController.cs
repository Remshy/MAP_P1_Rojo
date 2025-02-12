using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform _myTransform;
    public int maxhealth; 
    private int initialmaxhealth;
    public GameObject Rupia;
    public GameObject RupiaAzul;
    public GameObject Corazon;
    public GameObject explosion;
    private void Awake()
    {
        //Esto luego se har� algo para cambiarlo para cada enemigo, �con un public o algo as�?
       initialmaxhealth = maxhealth = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        //para saber la posici�n donde crear los prefabs
        _myTransform = transform;
    }
    public void Damaged(int i) 
    {
        maxhealth-=i;
        Debug.Log(maxhealth + " " + i);
        if (maxhealth <= 0) { Death(); }  
    }
    private void Death()
    {
        ExplosionMuerte();
        Drop();
        Destroy(gameObject);
    }
    public void ExplosionMuerte()
    {
        GameObject ex = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(ex, 0.5f);
    }
    private void Drop()
    {
        //decidir cu�l ser� el drop para el enemigo
        int i;
         Randomize(100,out i);
        i +=  initialmaxhealth*2;
        if (i <= 40) { }
        else if(i<=65)
        {
            Instantiate(Rupia, _myTransform.position,new Quaternion (0,0,0,0));
        }
        else if (i <= 90) 
        {
           Instantiate(Corazon, _myTransform.position, new Quaternion(0, 0, 0, 0));
        }
        else if (i >90) 
        {
            Instantiate(RupiaAzul, _myTransform.position, new Quaternion(0, 0, 0, 0));
        }

    }
     private void Randomize(int max, out int i)
    {
       i= Random.Range(0,max);       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if(playerController)
        {
            if(playerController.stateA)
            {
                Damaged(10);
            }
            else
            {
                VidaSystem vidaSys = collision.gameObject.GetComponent<VidaSystem>();
                if (vidaSys)
                {
                    vidaSys.vida--;
                }
                PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
                if (pc)
                {
                    pc.LooseHeath();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
