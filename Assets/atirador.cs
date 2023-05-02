using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atirador : MonoBehaviour
{
    public GameObject tiro;
    public Transform position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void atirar(){
        Instantiate(tiro,position.position,Quaternion.Euler(0,0,-90));
    }
}
