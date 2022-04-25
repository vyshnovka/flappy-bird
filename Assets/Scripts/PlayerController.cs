using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip tapSound;
    [SerializeField]
    private AudioClip deathSound;

    [SerializeField]
    private float forceSpeed = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = Vector3.up * forceSpeed;

            audioSource.PlayOneShot(tapSound, 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("isDead", true);
        audioSource.PlayOneShot(deathSound, 1f);

        UIManager.instance.ShowRestartUI();
    }
}
