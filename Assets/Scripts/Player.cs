using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     private float _speed = 390f;
     private float _scaleSpeed = 0.06f;
     private float _min = 0.5f, _max = 2f;

    public AudioSource Audio;
    private Rigidbody Rb;

    private Vector3 _maxScaleR,_minScaleL;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        Audio = GetComponent<AudioSource>();
        _maxScaleR = new Vector3(_min, _max,0.5f);
        _minScaleL = new Vector3(_max, _min,0.5f);
    }

    void Update()
    {
        PlayerController();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Rb.velocity = new Vector3(Rb.velocity.x,Rb.velocity.y,_speed * Time.deltaTime);
    }
    private void PlayerController()
    {
        if (Input.GetKey(KeyCode.Mouse0) && transform.localScale != _maxScaleR)
        {
            transform.localScale += new Vector3(0f, _scaleSpeed, 0f);
            transform.localScale -= new Vector3(_scaleSpeed, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.Mouse1) && transform.localScale != _minScaleL)
        {
            transform.localScale -= new Vector3(0f, _scaleSpeed, 0f);
            transform.localScale += new Vector3(_scaleSpeed, 0f, 0f);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Object")
        {
            Audio.Play();
        }
    }

}
