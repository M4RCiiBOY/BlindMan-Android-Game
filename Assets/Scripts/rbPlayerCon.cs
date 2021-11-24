using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rbPlayerCon : MonoBehaviour
{
    bool crouch;
    public GameObject CroucheDecoil;
    public GameObject Player;
    public Rigidbody rb;
    public BoxCollider uperBox;
    public Transform groundCheck;
    public float speed;
    public int jumpCount;
    public int springer;
    public int ducker;
    public float jump;
    public bool allowtoMove;
    public interfaceCon interCon;
    

    bool onGround;
    float sec;
    int min;

    // Use this for initialization
    void Start()
    {
        jumpCount = 0;
        crouch = false;
        allowtoMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
 

        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x > Screen.width / 2 && !crouch && allowtoMove)
            {
                PlayerInputJump();
                
            }

            if (touch.position.x < Screen.width/2 && allowtoMove)
            {
                PlayerInputCrouch();

            }
        }
    }
    

    private void FixedUpdate()
    {
        Grounded();
        DebugClock();
    }



    void DebugClock()
    {
        sec += Time.deltaTime;
        if (sec >= 60f)
        {
            sec = 0f;
            min++;
        }

    }


    /// <summary>
    /// For the Automatic Movement to the right
    /// </summary>
    void Move()
    {
        RaycastHit hit;

        if (Physics.Raycast(Player.transform.position, Player.transform.right, out hit, .5f))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Player.transform.position = new Vector3(Player.transform.position.x - 5, Player.transform.position.y, Player.transform.position.z);
            }
        }
        else
        {
            Player.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

        }

    }

    /// <summary>
    /// Checks if the Player is on Ground
    /// </summary>
    void Grounded()
    {
        if (Physics.Raycast(Player.transform.position, -Player.transform.up, .6f))
        {
            onGround = true;
            jumpCount = 0;
        }
    }
    /// <summary>
    /// For the Player Input
    /// </summary>
    public void PlayerInputJump()
    {
        if (jumpCount == 0 && onGround)
        {
            onGround = false;
            jumpCount++;
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
           
           // Debug.Log("Time for jump: " + min + ":" + sec);
            
        }
    }

    public void PlayerInputCrouch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            crouch = true;
            CroucheDecoil.SetActive(false);
            uperBox.center = new Vector3(0, 0, 0);

            //Debug.Log("Time crouch start: " + min + ":" + sec);
        }

        if (Input.GetMouseButtonUp(0))
        {
            crouch = false;
            CroucheDecoil.SetActive(true);
            uperBox.center = new Vector3(0, 1, 0);

            //Debug.Log("Time crouch stop: " + min + ":" + sec);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "powerup")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag=="Level")
        {
            Vector3 crash = Player.transform.position - collision.transform.position;
            if (crash.x <= 0f && crash.y <= 0f)
            {
                interCon.OpenDeadScrren();
            }
        }
    }
}

