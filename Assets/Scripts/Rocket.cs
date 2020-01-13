using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    /*float xMov;
    float yMov;*/

    [SerializeField] float rotationSpeed = 200f;
    [SerializeField] float thrustForce = 800f;

    private const string friendlyTag = "Friendly";

    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        /*xMov = Input.GetAxis("Horizontal");
        yMov = Input.GetAxis("Vertical");

        transform.Translate(xMov, 0f, yMov);*/
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case friendlyTag:
                print("OK");
                break;
            default:
                print("Dead");
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float addedForce = thrustForce * Time.deltaTime;

            rb.AddRelativeForce(Vector3.up * addedForce);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        rb.freezeRotation = true;

        float rcsThrust = rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rcsThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rcsThrust);
        }

        rb.freezeRotation = false;
    }
}
