using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareMotion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 globalPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(globalPos.x,globalPos.y, 0f);   
    }

        void OnTriggerEnter2D(Collider2D collisor){
        if(collisor.gameObject.layer == 6){
            addingTowers.canadd = true;
           
        }
    }
    void OnTriggerExit2D(Collider2D collisor){
            if(collisor.gameObject.layer == 6){
                addingTowers.canadd = false;
        }
    }
}
