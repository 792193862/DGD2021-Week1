using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleController : MonoBehaviour
{
    private Vector3 move;
    // the world-relative desired move direction, calculated from the camForward and user input.

    private Transform cam; // A reference to the main camera in the scenes transform
    private Vector3 camForward; // The current forward direction of the camera

    private bool jump;

    [SerializeField] private float m_MovePower = 500; // The force added to the player to move it.            

    private const float k_GroundRayLength = 1f; // The length of the ray to check if the player is grounded.
    private Rigidbody m_Rigidbody;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();       
    }


    private void Awake()
    {
        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");        


        if (cam != null)
        {
            // calculate camera relative direction to move:
            camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
            move = (v * camForward + h * cam.right).normalized;
        }
    }

    private void FixedUpdate()
    {
        Move(move);
    }



   
   
    public void Move(Vector3 moveDirection)
    {             
        // Otherwise add force in the move direction.
        m_Rigidbody.AddForce(moveDirection * m_MovePower);               
    }


}
