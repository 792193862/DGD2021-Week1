using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertInput : MonoBehaviour
{

    public float effectDuration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerBehaviour>())
        {
            other.GetComponent<PlayerBehaviour>().InvertInput(effectDuration);
            RemoveFromGame();
        }
    }

    void RemoveFromGame()
    {
        Destroy(this.gameObject);
    }
}

