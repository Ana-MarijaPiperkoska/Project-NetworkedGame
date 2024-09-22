using System;
using Unity.Netcode;
using Unity.Networking.Transport;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    private BoxCollider2D collider;
    private float moveX = 0f;
    private float speed = 3f;
    private float jumpForce = 9f;
   
    [SerializeField] private LayerMask ground;
    public GameObject playerUIPrefab; 
    public PlayerUI playerUIController;

   
    private enum MovementState
    {
        idle,
        running,
        jumping,
        falling
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        if (IsOwner)
        {
            SetupPlayerUI();
        }
    }

    private void Update()
    {

        if (!IsOwner || !Application.isFocused) return;

        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (IsOwner)
        {
            Camera mainCamera = Camera.main;

            if (mainCamera != null)
            {
               
                CameraController cameraFollow = mainCamera.GetComponent<CameraController>();
                if (cameraFollow != null)
                {
                    cameraFollow.SetTarget(this.transform); 
                }
            }
            
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (moveX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (moveX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }


    private bool IsGrounded()
    {
       return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, ground);
    }

       private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!IsOwner) return; 

           
            if (collision.gameObject.CompareTag("FinishLine"))
            {
                if (IsServer) 
                {
                GameWonClientRpc(NetworkManager.Singleton.LocalClientId);
                
            }
            
        }
        
        }
    [ServerRpc(RequireOwnership = false)]
    private void TouchFinishLineServerRpc(ulong clientId)
    {
       
        GameWonClientRpc(clientId);
    }
    [ClientRpc]
    private void GameWonClientRpc(ulong winningClientId)
    {
        if (playerUIController == null)
        {
            SetupPlayerUI();
        }

        if (playerUIController != null)
        {
            if (NetworkManager.Singleton.LocalClientId == winningClientId)
            {
              
                playerUIController.DisplayEndMessage(true); 
            }
            else
            {
               
                playerUIController.DisplayEndMessage(false);
            }
           
            Time.timeScale = 0;
        }
        else
        {
            Debug.LogError("PlayerUIController is not set for the client.");
        }
    }
    private void SetupPlayerUI()
        {
            
            playerUIController = GetComponent<PlayerUI>();
            playerUIController.SetupUI(playerUIPrefab);
        }

}
