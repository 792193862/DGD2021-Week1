using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatamariFull : MonoBehaviour
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
        
        if (collision.gameObject.GetComponent<CollectibleCube>())
        {
            collision.gameObject.GetComponent<CollectibleCube>().AttachTo(this.transform);
        }
    }

}
