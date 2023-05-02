using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public static float vida = 100; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida<=0){
            transform.position = new Vector3(-100, 0,0);
            Destroy(gameObject,1f);
        }
        
    }
    public static void danoCounter(int dano){
        vida -= dano;
    }

}
