using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Parameters - for tuning, typically set in the editor

    [SerializeField] float thrustSpeed = 100f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftEngineParticles;
    [SerializeField] ParticleSystem rightEngineParticles;

    // Cache - e.g. refereneces for readability or speed

    Rigidbody rb;
    AudioSource audioSource;

    // State - private instance (member) variable




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();

        }
        else
        {
            StopThrusting();
        }

    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }


    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }

    }
    void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

   private void RotateLeft()
    {
        ApplyRotation(rotationSpeed);
        rightEngineParticles.Play();
    }

    private void RotateRight()
    {
        ApplyRotation(-rotationSpeed);
        leftEngineParticles.Play();
    }
    void StopRotating()
    {
        rightEngineParticles.Stop();
        leftEngineParticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so physics system can take over
        

    }
}
