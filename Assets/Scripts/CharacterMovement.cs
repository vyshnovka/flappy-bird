using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float birdSpeed = 1f;
    private Rigidbody2D birdRigidbody;

    void Start()
    {
        birdRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            birdRigidbody.velocity = Vector3.up * birdSpeed;

            this.transform.Find("TapSound").gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
