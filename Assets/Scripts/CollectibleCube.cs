using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetMass(float mass)
    {
        this.GetComponent<Rigidbody>().mass = mass;

        this.transform.localScale = new Vector3(mass/2, mass/2, mass/2);
    }

    public float GetMass()
    {
        return this.GetComponent<Rigidbody>().mass;
    }

    public void AttachTo(Transform t)
    {
        Destroy(this.GetComponent<Rigidbody>());
        this.GetComponent<Collider>().isTrigger = true;
        this.transform.SetParent(t);
    }
}
