using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public int myPoints;

    public int lives;

    public float levelDuration;

    public bool gameRunning;

    private SimpleController controls;    

    // Start is called before the first frame update
    void Start()
    {
        myPoints = 0;

        lives = 4;

        levelDuration = 1000;

        gameRunning = true;

        controls = GetComponent<SimpleController>();


    }


    void GameOver()
    {
        Destroy(this.gameObject.GetComponent<SimpleController>());
        levelDuration = 0f;
        gameRunning = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (gameRunning)
        {
            levelDuration -= Time.deltaTime;

            if ((lives <= 0) || (levelDuration <= 0))
            {
                GameOver();
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BasicCollectible>())
        {
            myPoints += collision.gameObject.GetComponent<BasicCollectible>().points;
            
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<SpeedPowerUp>())
        {
            controls.m_MovePower *= collision.gameObject.GetComponent<SpeedPowerUp>().speedModifier;

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "MovementModifier")
        {
            controls.invertMovement = true;

            Destroy(collision.gameObject);
        }

        else
        {            
            lives--;
            if (collision.gameObject.tag != "Environment")
            {
                Destroy(collision.gameObject);
            }
        }
    }

    
}
