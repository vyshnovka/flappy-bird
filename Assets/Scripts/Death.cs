using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Animator animator;

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("isDead", true);
        this.transform.Find("DeathSound").gameObject.GetComponent<AudioSource>().Play();

        UIManagement.state = UIManagement.States.Restart;
    }
}
