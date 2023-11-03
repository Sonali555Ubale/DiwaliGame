using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;


public class PlayerMovement1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerMovement playerMovement;
    private SpriteRenderer sprite;
    private Animator animator;

    private float dirX = 0f;
    private float moveSpeed = 1f;
    private float jumpForce = 20f;

    private bool facingRight = true;
    private bool ParticleFacegRight = true;
    [SerializeField]
    private ParticleSystem FirecrackerEffect;

   /* [SerializeField]
    private AudioSource jumpSound;*/


   public enum MovementState {IdlePlayer, PlayerAnim1}

    private void Awake()
    {
        playerMovement = new PlayerMovement();
    }

    private void OnEnable()
    {
        playerMovement.PlayerMove.Move.Enable();
       
    }


    private void FixedUpdate()
    {
        CheckforMovementInput();
    }

    private void CheckforMovementInput() => OnMove(playerMovement.PlayerMove.Move.ReadValue<float>());

    private void OnDisable()
    {
        playerMovement.PlayerMove.Move.Disable();
        
    }


    public void OnMove(float context)
    {
        dirX = context;
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        UpdateMovementAnimations();
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FirecrackerEffect = GetComponent<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
        if (sprite == null) sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if(animator == null) animator = GetComponentInChildren<Animator>();
       
        
    }
    private void UpdateMovementAnimations()
    {
        MovementState state;

        if (dirX != 0f)
            state = MovementState.PlayerAnim1;


        else
            state = MovementState.IdlePlayer;

        if (dirX > 0f && !facingRight && !ParticleFacegRight) 
        {
            FlipXAxis();
        }
        else if (dirX < 0f && facingRight && ParticleFacegRight)
        {
            FlipXAxis();

        }

        if (!ParticleFacegRight)
            FlipParticles();
        if (ParticleFacegRight)
            FlipParticles();

        animator.SetInteger("State", (int)state);
    }


    private void FlipXAxis()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
        ParticleFacegRight = !ParticleFacegRight;
        

    }
    private void FlipParticles()
    {
        ParticleSystem p = GetComponentInChildren<ParticleSystem>();
        if (!ParticleFacegRight)
        {

            p.transform.localRotation = Quaternion.Euler(-1.0f, 60.0f, -90.0f);

        }
        else
            p.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 65.0f); ;


        // p.transform.rotation = Quaternion.EulerRotation(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z*2);
        //p.transform.localScale = new Vector3(-0.5f, 0.5f,0.5f);
    }





}
