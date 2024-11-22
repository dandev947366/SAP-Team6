using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private IInteractable nearbyInteractable;
    public float speed;
    private float inputX;
    private float inputY;
    private Vector2 movementInput;
    private bool hasMoved = false;

    public SpriteRenderer spriteRender;
    public float interactionRadius = 1f;
    private bool isRunning = false; // 用于检测是否按住 Shift

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void PlayerInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        if (inputX != 0 && inputY != 0)
        {
            inputX = inputX * 0.6f;
            inputY = inputY * 0.6f;
        }

        movementInput = new Vector2(inputX, inputY);

        // 检测是否按住 Shift 键
        isRunning = Input.GetKey(KeyCode.LeftShift);

        // 检测玩家是否开始移动
        if (movementInput != Vector2.zero)
        {
            hasMoved = true;
            if (inputX > 0)
            {
                spriteRender.flipX = true;
            }
            else if (inputX < 0)
            {
                spriteRender.flipX = false;
            }
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // 更新动画中的奔跑状态
        // animator.SetBool("isRunning", isRunning);
    }

    private void Update()
    {
        PlayerInput();

        if (Input.GetKeyDown(KeyCode.E) && nearbyInteractable != null)
        {
            nearbyInteractable.Interact();
            animator.SetTrigger("Interact");
        }
    }

    private void FixedUpdate()
    {
        Movement();
        DetectNearbyInteractable();
    }

    private void Movement()
    {
        // 根据是否按住 Shift 调整速度
        float currentSpeed = isRunning ? speed * 2f : speed;
        rb.MovePosition(rb.position + movementInput * currentSpeed * Time.fixedDeltaTime);
    }

    private void DetectNearbyInteractable()
    {
        if (!hasMoved) return;

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRadius);
        IInteractable closestInteractable = null;
        float closestDistance = Mathf.Infinity;

        foreach (var hit in hits)
        {
            IInteractable interactable = hit.GetComponent<IInteractable>();
            if (interactable != null)
            {
                float distance = Vector2.Distance(transform.position, hit.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestInteractable = interactable;
                }
            }
        }

        if (closestInteractable != nearbyInteractable)
        {
            nearbyInteractable = closestInteractable;
            if (nearbyInteractable != null)
            {
                Debug.Log("Player entered interactable area of: " + nearbyInteractable);
            }
            else
            {
                Debug.Log("Player exited all interactable areas");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasMoved) return;

        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            nearbyInteractable = interactable;
            Debug.Log("Player entered interactable area of: " + interactable);
        }

        Collectible collectible = other.GetComponent<Collectible>();
        if (collectible != null)
        {
            collectible.Collect();
        }
    }
}
