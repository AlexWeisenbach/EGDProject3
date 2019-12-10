using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;
    Rigidbody rb;
    public GameObject camera;
    CursorLockMode lockMode;

    public GameObject handSymbolThing;
    public float interactRange;

    public TimerAndAccuse acc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handSymbolThing.SetActive(false);
        lockMode = CursorLockMode.Locked;
        Cursor.lockState = lockMode;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement stuff
        //Debug.Log(camera.transform.forward);
        print(rb.velocity);
        if(Input.GetKey("w"))
        {
            //float xMovement = walkSpeed * Mathf.Cos(transform.localRotation.y);
            //float zMovement = walkSpeed * Mathf.Sin(transform.localRotation.y);

            //transform.position = new Vector3(transform.position.x + xMovement, transform.position.y, transform.position.z + zMovement);

            //Debug.Log("Forward");
            rb.velocity = Vector3.Normalize(rb.velocity + new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z)) * walkSpeed;
        }
        else if (Input.GetKey("s"))
        {
            //Debug.Log("Back");
            rb.velocity = Vector3.Normalize(rb.velocity + -1* new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z)) * walkSpeed;
        }
       if(Input.GetKey("a"))
        {
            //Debug.Log("Left");
            rb.velocity = Vector3.Normalize(rb.velocity + -1 * new Vector3(camera.transform.right.x, 0, camera.transform.right.z)) * walkSpeed;
        }
        else if (Input.GetKey("d"))
        {
            //Debug.Log("Right");
            rb.velocity = Vector3.Normalize(rb.velocity + new Vector3(camera.transform.right.x, 0, camera.transform.right.z)) * walkSpeed;
        }
        if(!Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d"))
        {
            //Debug.Log("Stopped");
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        //Interaction stuff
        RaycastHit info;
        Physics.Raycast(transform.position, camera.transform.forward, out info, interactRange);
        if(info.collider != null && info.collider.gameObject.tag == "Interactable")
        {
            handSymbolThing.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                info.collider.gameObject.SendMessage("InteractedWith");
            }

        }
        else
        {
            handSymbolThing.SetActive(false);
        }

        if(Input.GetKeyDown("p"))
        {
            acc.Accuse();
        }
        
    }
}
