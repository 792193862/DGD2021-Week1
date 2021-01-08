using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    public GameObject collectibleCube;

    private float maxDistanceFromCentre;

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        //I am using an arbitrary number here

        maxDistanceFromCentre = 20f;

        timer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnCube();
            timer = 5f;
        }
            
    }

    public void SpawnCube()
    {
        GameObject newCube = Instantiate(collectibleCube);

        newCube.GetComponent<CollectibleCube>().SetMass(Random.Range(0.1f, 1f));

        newCube.transform.position = new Vector3(Random.Range(0f, maxDistanceFromCentre), 0.5f, Random.Range(0f, maxDistanceFromCentre));
    }
}
