using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public int cubesCollected;


    // Start is called before the first frame update
    void Start()
    {
        cubesCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            cubesCollected++;
            
            Destroy(collision.gameObject);
        }
    }
}
