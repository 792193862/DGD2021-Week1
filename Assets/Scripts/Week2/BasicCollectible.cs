﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCollectible : MonoBehaviour
{

    public int points;    

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
            other.GetComponent<PlayerBehaviour>().AddPoints(points);            

            RemoveFromGame();
        }
    }

    void RemoveFromGame()
    {
        Destroy(this.gameObject);
    }
}
