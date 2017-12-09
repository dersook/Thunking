using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private enum JumpState
    {
        Ground,
        Jumping,
        Slowing,
        Falling
    }

    public float horizontalMoveSpeed = 5f;
    public float acceleration = 40f;

    public float jumpHeight = 10f;
    public float jumpForce = 10f;
    public float jumpLerpTime = 0.1f;
    private float jumpApex;
    private JumpState jumpState = JumpState.Ground;

    public float evadeDistance = 1f;
    public float evadeTime = 0.05f;
    public float evadeCooldown = 2f;
    private float lastTimeEvadeUsed;


    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Status characterState;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterState = GetComponent<Status>();
    }

    void LateUpdate()
    {
        if (rb2d.velocity.y < 0)
        {
            jumpState = JumpState.Falling;
        }
    }

    public void Input(InputIteration data)
    {
        MoveHorizontal(data.movement.horizontalMovement);
        HandleJump(data.movement.jump);
        Evade(data.movement.evade, data.movement.horizontalMovement, data.movement.evadeDirection);
    }

    private void MoveHorizontal(float direction)
    {
        float horizontalVelocity = 0f;
        if (characterState.isEvading) return;
        if (direction > 0.0f)
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        if (direction < 0.0f)
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        if (direction == 0f) {
            if (Mathf.Abs(rb2d.velocity.x) < 1) {
                horizontalVelocity = 0f;
            } else if (rb2d.velocity.x > 0) {
                horizontalVelocity = rb2d.velocity.x - (2 * acceleration * Time.deltaTime);
            } else {
                horizontalVelocity = rb2d.velocity.x + (2 * acceleration * Time.deltaTime);
            }
        } else if (rb2d.velocity.x < 0 && direction > 0) {
            horizontalVelocity = rb2d.velocity.x + (2 * acceleration * Time.deltaTime);
        } else if (rb2d.velocity.x > 0 && direction < 0) {
            horizontalVelocity = rb2d.velocity.x - (2 * acceleration * Time.deltaTime);
        } else if (Mathf.Abs(rb2d.velocity.x) < horizontalMoveSpeed){
            horizontalVelocity = rb2d.velocity.x + (direction * acceleration * Time.deltaTime);
        } else {
            horizontalVelocity = rb2d.velocity.x;
        }

        rb2d.velocity = new Vector2(horizontalVelocity, rb2d.velocity.y);
    }
    int startedJump = -1;
    private void HandleJump(bool jump)
    {
        AutoUpdateJumpState();
        if (jumpState == JumpState.Ground && jump)
        {
            jumpState = JumpState.Jumping;
            jumpApex = transform.position.y + jumpHeight;
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
        if (jumpState == JumpState.Jumping && ((transform.position.y >= jumpApex) || !jump))
        {
            jumpState = JumpState.Falling;
            StartCoroutine("LerpToStopCoroutine");
        }
    }

    private void AutoUpdateJumpState()
    {
        if ((jumpState == JumpState.Jumping || jumpState == JumpState.Slowing) && rb2d.velocity.y <= 0)
        {
            jumpState = JumpState.Falling;
        }
        else if (jumpState == JumpState.Falling && rb2d.velocity.y == 0)
        {
            jumpState = JumpState.Ground;
        }
    }

    IEnumerator LerpToStopCoroutine()
    {
        float startTime = Time.time;
        float originalYVelocity = rb2d.velocity.y;
        while (rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Lerp(originalYVelocity, 0f, (Time.time - startTime) / jumpLerpTime));
            yield return null;
        }
    }

    private void Evade(bool evade, float direction, int evadeDirection)
    {
        if (evade && (Time.time - lastTimeEvadeUsed) > evadeCooldown && !characterState.isBusy)
        {
            lastTimeEvadeUsed = Time.time;
            StartCoroutine("EvadeCoroutine", direction);
        } else if(evadeDirection != 0 && (Time.time - lastTimeEvadeUsed) > evadeCooldown && !characterState.isBusy) {
            lastTimeEvadeUsed = Time.time;
            StartCoroutine("EvadeCoroutine", evadeDirection);
        }
    }

    public bool IsJumping()
    {
        return jumpState == JumpState.Jumping;
    }

    public bool IsFalling()
    {
        return jumpState == JumpState.Falling;
    }

    IEnumerator EvadeCoroutine(float direction)
    {
        //direction = transform.rotation.y == 0 ? 1f : -1f ;

        rb2d.velocity = new Vector2((evadeDistance / evadeTime) * direction, rb2d.velocity.y);



        spriteRenderer.enabled = true;
        characterState.isEvading = true;
        enabled = true;
        gameObject.layer = 10;
        yield return new WaitForSeconds(evadeTime);
        gameObject.layer = 0;
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        spriteRenderer.enabled = true;
        enabled = true;
        characterState.isEvading = false;
    }
}
