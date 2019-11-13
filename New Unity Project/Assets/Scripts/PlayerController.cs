using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;
    Rigidbody rb;
    CursorLockMode lockMode;

    public GameObject handSymbolThing;
    public float interactRange;
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
        if(Input.GetKey("w"))
        {
            //float xMovement = walkSpeed * Mathf.Cos(transform.localRotation.y);
            //float zMovement = walkSpeed * Mathf.Sin(transform.localRotation.y);

            //transform.position = new Vector3(transform.position.x + xMovement, transform.position.y, transform.position.z + zMovement);

            rb.velocity = transform.forward * walkSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        //Interaction stuff
        RaycastHit info;
        Physics.Raycast(transform.position, transform.forward, out info, interactRange);
        if(info.collider != null && info.collider.gameObject.tag == "Interactable")
        {
            handSymbolThing.SetActive(true);

        }
        else
        {
            handSymbolThing.SetActive(false);
        }

        if(Input.GetMouseButtonDown(0) && info.collider != null)
        {
            info.collider.gameObject.SendMessage("InteractedWith");
        }
    }
}
