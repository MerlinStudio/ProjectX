using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveChar : MonoBehaviour
{
    public Button JumpButton;
    public Sprite Moving;
    public Sprite Stay;
    Rigidbody2D Rigidbody2D;

    public float Speed;
    public float JumpPower;


    public Transform GroundCheck;
    public static float _checkRadius = 0.3f;
    public LayerMask GroundLayer;
    public static bool isGrounded;

    private bool onMoving, directionRight;
    private SpriteRenderer SpriteRenderer;

    private float codeTimer;

    void Start()
    {
        JumpButton.onClick.AddListener(Jump);
        codeTimer = 0;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(codeTimer > 0) { codeTimer -= Time.fixedDeltaTime; }

        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, _checkRadius, GroundLayer);
        MoveLogic();
        ControllPC();
    }

    private void MoveLogic()
    {
        if (onMoving)
        {
            SpriteRenderer.sprite = Moving;
            if (directionRight)
            {
                SpriteRenderer.flipX = true;
                Rigidbody2D.AddForce(Vector2.right * Speed, ForceMode2D.Impulse);
            }
            else
            {
                SpriteRenderer.flipX = false;
                Rigidbody2D.AddForce(Vector2.left * Speed, ForceMode2D.Impulse);
            }
        }
        else SpriteRenderer.sprite = Stay;
    }
    private void ControllPC()
    {
        if (Input.GetKey(KeyCode.A))
        {
            directionRight = false;
            onMoving = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            onMoving = directionRight = true;
        }
        else onMoving = false;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && codeTimer <= 0)
        {
            Rigidbody2D.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            codeTimer = 0.2f;
        }
    }

    public void OnDoAction(int action)
    {
        if (action == 1)
        {
            onMoving = directionRight = true;
        }
        else if (action == 2)
        {
            directionRight = false;
            onMoving = true;
        }
        else if (action == 0)
        {
            onMoving = false;
        }
    }

    private void Jump()
    {
        if (isGrounded && codeTimer <= 0 && !Healths.damage)
        {
            Rigidbody2D.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            codeTimer = 0.2f;
        }
    }
}
