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

    private float originalMovePower;

    // Start is called before the first frame update
    void Start()
    {
        myPoints = 0;

        lives = 4;

        levelDuration = 1000;

        gameRunning = true;

        controls = GetComponent<SimpleController>();

        originalMovePower = controls.m_MovePower;
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

    IEnumerator RunEffectSpeed(float duration)
    {
        while (duration > 0)
        {
            duration -= Time.deltaTime;
            yield return null;
        }

        RestoreSpeed();        
    }


    IEnumerator RunEffectInvertAxis(float duration)
    {
        while (duration > 0)
        {
            duration -= Time.deltaTime;
            yield return null;
        }

        RevertInput();
    }

    public void AddPoints(int numberOfPoints)
    {
        myPoints += numberOfPoints;
    }

    public void ChangeSpeed(float modifier, float duration)
    {        
        controls.m_MovePower *= modifier;        
        StartCoroutine("RunEffectSpeed", duration);
    }


    public void RestoreSpeed()
    {
        controls.m_MovePower = originalMovePower;
    }

    public void InvertInput(float duration)
    {
        controls.invertMovement = true;
        StartCoroutine("RunEffectInvertAxis", duration);
    }

    public void RevertInput()
    {
        controls.invertMovement = false;
    }
        

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Environment")
        {            
            lives--;            
        }
    }

    
}
