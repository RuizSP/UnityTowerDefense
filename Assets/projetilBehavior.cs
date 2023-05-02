using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D rig;
    void Start()
    {
       rig = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
     rig.velocity = new Vector3(speed, 0f,0f );   
    }

    void OnBecameInvisible()
{

    Destroy(gameObject);
}
}
