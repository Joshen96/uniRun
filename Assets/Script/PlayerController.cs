using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 700f;
    int jumpCount = 0;
    bool isGrounded = false;
    bool isDead = false;

    Rigidbody2D p_rigi;
    Animator animator;
    AudioSource p_audio;


    void Start()
    {

        // 컴포넌트 할당 
        p_rigi = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        p_audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0)&& jumpCount<2)
        {
            jumpCount++;
            p_rigi.velocity = Vector2.zero;

            p_rigi.AddForce(new Vector2(0, jumpForce));
            p_audio.Play(); //점프 소리
            
        }
        else if(Input.GetMouseButtonUp(0)&& p_rigi.velocity.y>0 )
        {
            p_rigi.velocity = p_rigi.velocity * 0.5f;
        }
        animator.SetBool("Grounded", isGrounded);
    }


    void Die()
    {
        animator.SetTrigger("Die");
        p_audio.clip = deathClip;
        p_audio.Play();

        p_rigi.velocity = Vector2.zero;
        isDead = true;

        GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Dead"&& !isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
