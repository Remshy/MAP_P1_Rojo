using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform _myTransform;
    int maxhealth, initialmaxhealth;
    private void Awake()
    {
        //Esto luego se har� algo para cambiarlo para cada enemigo, �con un public o algo as�?
       initialmaxhealth= maxhealth = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        //para saber la posici�n donde crear los prefabs
        _myTransform = transform;
    }
    public void Damaged() 
    {
        maxhealth--;
        if (maxhealth <= 0) { Death(); }  
    }
    private void Death()
    {
        Drop();
        Destroy(this);
    }
    private void Drop()
    {
        //decidir cu�l ser� el drop para el enemigo
        int i;
         Randomize(100,out i);
        i = i * initialmaxhealth;
        if (i <= 40) { }
        else if(i<=65)
        {
            // Instantiate(rup�, _myTransform.position)
        }
        else if (i <= 90) 
        {
            //Instantiate (vida, _myTransform.position)
        }
        else if (i >90) 
        {
            //Instantiate (rup� azul, _myTransform.position)
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
}
