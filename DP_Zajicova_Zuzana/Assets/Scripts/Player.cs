using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public Transform GroundCheckTransform;
    public LayerMask Ground;

    private bool jumKeyWasPressed;
    private float horizontalInput;
    private Rigidbody2D rigidbodyComponent;

    public float speed;
    public float jumpForce;

    private bool onGround;
    public UnityEvent OnLandEvent;


    public Animator animator;

    bool facingRight = true;

    public LifeCount lifeCount;

    Vector2 mousePos;

    private Vector2 screenBounds;


    float timeLeft;
    float visibleCursorTimer = 0.2f;



    private void Awake()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        animator.SetBool("IsStanding", true);
    }
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        mousePos = transform.position;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        
    }


    void Update()
    {
        //zmizen� krabi�ky, kterou hr�� dr�� v p��pad� v�skoku
        GameObject z = transform.GetChild(2).gameObject;
        if (onGround != true)
        {
            z.SetActive(false);
        }
        if (onGround == true && !animator.GetBool("IsStanding"))
        {
            z.SetActive(true);
        }

        if (Time.timeScale ==0f)
            {
                z.SetActive(false);
            }

        //za��tek st�n�

        if (animator.GetBool("IsStanding"))
            {
                z.SetActive(false);
            }
        

        if (Input.anyKeyDown && animator.GetBool("IsStanding"))
        {
            animator.SetBool("IsStanding", false); 
        }

        //sk�k�n�
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            jumKeyWasPressed = true;
            animator.SetBool("IsJumping", true);
        }

        //animace po ztr�t� v�ech �ivot�
        if (LifeCount.lifeCount.lifesRemaining == 0)
        {
            animator.SetBool("Over", true);
        }


        horizontalInput = Input.GetAxis("Horizontal");

        //Set yVelocity in the animator
        animator.SetFloat("yVelocity", rigidbodyComponent.velocity.y);


        //mouse follow

        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //pokud hr�� neh�be my�� kurzor zmiz�
        if (Input.GetAxis("Mouse X") == 0 || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = visibleCursorTimer;
                Cursor.visible = false;
            }

        }
        else
        {
            timeLeft = visibleCursorTimer;
            Cursor.visible = true;
        }

    }



    private void FixedUpdate()
    {

        onGround = Physics2D.OverlapCircle(GroundCheckTransform.position, 0.1f, Ground);
        float horizontal = Input.GetAxis("Horizontal");

        //mouse follow
        //kdy� nen� viditeln� kurzor, rychlost hr��e podle �ipek
        if (Cursor.visible == false || (mousePos.x < -screenBounds.x - 1 || mousePos.x > screenBounds.x + 1 || mousePos.y < -screenBounds.y || mousePos.y > screenBounds.y) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))

        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        }

        //kurzor viditeln� a v hern�m poli
        if ((mousePos.x > -screenBounds.x - 1 && mousePos.x < screenBounds.x + 1 && mousePos.y > -screenBounds.y && mousePos.y < screenBounds.y) && Cursor.visible == true)

        {
            Vector3 followXonly = new Vector3(mousePos.x, transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, followXonly, speed * Time.fixedDeltaTime);
            animator.SetFloat("Speed", 1);
        }


        //jumping
        if (jumKeyWasPressed && onGround == true)
        {
            rigidbodyComponent.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumKeyWasPressed = false;
        }

        animator.SetBool("IsJumping", !onGround);
        rigidbodyComponent.velocity = new Vector2(horizontal * speed, rigidbodyComponent.velocity.y);

        var playerScreenPoint = Camera.main.WorldToScreenPoint(animator.transform.position);
        var mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        //Flip player
        //�ipky
        if (horizontal < 0 && facingRight)
        {
            Flip();
        }
        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }
        //my�
        if (mouse.x < playerScreenPoint.x && facingRight && Cursor.visible == true && (mousePos.x > -screenBounds.x - 1 && mousePos.x < screenBounds.x + 1 && mousePos.y > -screenBounds.y && mousePos.y < screenBounds.y))
        {
            Flip();
        }
        if (mouse.x > playerScreenPoint.x && !facingRight && Cursor.visible == true && (mousePos.x > -screenBounds.x - 1 && mousePos.x < screenBounds.x + 1 && mousePos.y > -screenBounds.y && mousePos.y < screenBounds.y))
        {
            Flip();
        }

    }
    //oto�it hr��e i s krabi�kou a textem
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
        transform.GetChild(2).Rotate(0f, 180f, 0f);
    }


    //maz�n� vyhozen�ch p�smen ve skoku
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject != onGround && collision.gameObject.name == "pismeno(Clone)")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("Delete_iy");
        }
    }


}
