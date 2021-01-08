using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatamariPlain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncreaseSize()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        //CHECK IF THIS IS A COLLECTIBLE CUBE
        if (collision.gameObject.GetComponent<CollectibleCube>())
        {            
            //
            
            
            //IF IT IS, DESTROY THAT COLLECTIBLE CUBE

            
        }
    }

}
