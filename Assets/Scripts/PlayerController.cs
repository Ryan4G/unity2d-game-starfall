using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float speed;
    float xVelocity;

    public bool isOnGround;
    public float checkRadius;
    public LayerMask platfrom;
    public GameObject groundCheck;

    bool playerDead;
    private AudioSource bgm;
    public AudioClip[] clips;
    public int Stars = 0;
    public Text StarNum;
    public Joystick joystick;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bgm = GetComponent<AudioSource>();
        
        bgm.clip = clips[0];
        bgm.Play();
    }

    
    void Update()
    {
        anim.SetBool("isOnGround", isOnGround);
        isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position,checkRadius,platfrom);
        Movement();
    }

    void Movement()
    {
        xVelocity = joystick.Horizontal;

        rb.velocity = new Vector2(xVelocity * speed,rb.velocity.y);
        
        anim.SetFloat("speed",Mathf.Abs(rb.velocity.x));//run

        if(xVelocity !=0)
        {
          transform.localScale = new Vector3(Mathf.Sign(xVelocity),1,1);
        }
        
    }
    public void PlayerDead()
    {
        playerDead = true;
        GameManager.GameOver(playerDead);

        bgm.Stop();
        //bgm.clip = clips[1];
        //bgm.Play();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("purple"))
        {
            rb.velocity = new Vector2(rb.velocity.x,5f);
        }
    }
    //private void OnTriggerEnter2D(Collider2D other)
       
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Collection")
       {
           Destroy(collision.gameObject);
           Stars += 1;
           StarNum.text = Stars.ToString();
       }

        
        if(collision.CompareTag("Spike"))
         {
            anim.SetTrigger("dead");
         }
        
    }
}

