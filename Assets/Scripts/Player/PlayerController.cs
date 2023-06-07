using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField]
    private float forceSpeed = 1f;

    void Start()
    {
        if (PlayerPrefs.GetInt("Decision", 0) == 1)
        {
            gameObject.SetActive(false);
        }

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = Vector3.up * forceSpeed;

            AudioController.instance.PlayTap();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            animator.SetBool("isDead", true);
            AudioController.instance.PlayDeath();

            CanvasManager.instance.ShowRestartButton();
        }
    }
}
