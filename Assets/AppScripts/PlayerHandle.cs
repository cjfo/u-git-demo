using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandle : MonoBehaviour
{

    public static int enemyCount = 1;

    private bool jumKeyPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    private bool isGounded;

    const int HEIGHT_FLY = 5;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        rigidbodyComponent = GetComponent<Rigidbody>();
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumKeyPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");// Edit\ProjectSetting\InputManager\Horizontal|Jump
    }

    // called once every physic update
    private void FixedUpdate()
    {
        if ( ! isGounded)
        {
            return;
        }

        if (jumKeyPressed)
        {
            
            Debug.Log("space pressed time " + enemyCount++);

            rigidbodyComponent.AddForce(Vector3.up * HEIGHT_FLY, ForceMode.VelocityChange);
            jumKeyPressed = false; // 1h24
        }

        //GetComponent<Rigidbody>().velocity = new Vector3(horizontalInput, 0, 0);
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
    }

    // this is debug TODO: Obj is grounded
    private void OnCollisionEnter(Collision collision)
    {
        isGounded = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGounded = true; 
    } // end isGrounded
}
