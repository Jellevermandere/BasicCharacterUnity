using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class TestScript : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    [SerializeField]
    private float movementSpeed, rotationSpeed, jumpSpeed, gravity;

    private Vector3 movementDirection = Vector3.zero;
    private bool playerGrounded;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerGrounded = characterController.isGrounded;
       
        Vector3 move = transform.forward * movementSpeed * Input.GetAxisRaw("Vertical");
        characterController.Move(move * Time.deltaTime);

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * rotationSpeed);
        }


        if (Input.GetButton("Jump") && playerGrounded)
        {
            movementDirection.y = jumpSpeed;
        }
        movementDirection.y -= gravity * Time.deltaTime;

        characterController.Move(movementDirection * Time.deltaTime);
        
        animator.SetBool("isRunning", Input.GetAxisRaw("Vertical") != 0);
        animator.SetBool("isJumping", !characterController.isGrounded);
        Debug.Log(characterController.isGrounded);
        
    }
}
