using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    public Vector2 movement;
    public AudioSource footstepAudio;

    private bool canMove; // Steuerung der Bewegungsf�higkeit

    private void Start()
    {
        if (footstepAudio == null)
        {
            footstepAudio = GetComponent<AudioSource>();
        }

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FoodStepAudioOn();

    }

    public void Move()
    {
        if (canMove)
        {
            // input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            SafeLastMovementDirection();
        }
        
    }

    private void SafeLastMovementDirection()
    {
        // Letzte Bewegungsrichtung speichern f�r Idle Animation
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
        }
    }

    private void FixedUpdate()
    {
        // movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private bool IsCharacterMoving()
    {
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }

    private void FoodStepAudioOn()
    {
        // �berpr�fe, ob der Charakter sich bewegt
        if (IsCharacterMoving() && canMove)
        {
            footstepAudio.enabled = true;
        }
        else
        {
            footstepAudio.enabled = false;
        }
    }

    public void MovementEnabled(bool enabled)
    {
        canMove = enabled;
    }


    public void SetMovementInputToZero()
    {
        movement.x = 0;
        movement.y = 0;

        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 0);
        animator.SetFloat("Speed", 0);
    }
}
