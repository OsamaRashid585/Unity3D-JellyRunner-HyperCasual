using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
     private float _moveSpeed = 390f;
     private float _scaleSpeed = 0.03f;
    [SerializeField] private ParticleSystem _explosion;

    private Rigidbody Rb;

    private Vector3 _verticalScale,_horizontalScale;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        _verticalScale = new Vector3(0.5f, 2,0.5f);
        _horizontalScale = new Vector3(2, 0.5f,0.5f);
        _explosion.Stop();
    }

    void Update()
    {
        PlayerController();
        
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    /* Summmary
     * Moving the Player in Forward Direction by using Rigidbody
       Summary */
    private void PlayerMovement()
    {
        Rb.velocity = new Vector3(Rb.velocity.x,Rb.velocity.y,_moveSpeed * Time.deltaTime);
    }

    /*Summary
     * Increasing/Decreasing the Size of an object with the help of Mouse button Right/Left
     Summary */
    private void PlayerController()
    {
        var MousePosY = Input.GetAxis("Mouse Y");
        var IsGrab = Input.GetKey(KeyCode.Mouse0);
        if (MousePosY > 0 && IsGrab)
        {
           transform.localScale = Vector3.Lerp(transform.localScale,_verticalScale, _scaleSpeed);
        }
        else if (MousePosY < 0 && IsGrab)
        {
           transform.localScale = Vector3.Lerp(transform.localScale, _horizontalScale, _scaleSpeed);

        }
    }

    /*Summary
     * If Player Hit Piller then GameOVer
     Summary */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piller"))
        {
            StartCoroutine(GameOverWait());
        }
    }
    IEnumerator GameOverWait()
    {
        _moveSpeed = 0;
        _explosion.Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    /*Summary
     * If player Pass Hurddle then score Increase
     Summary */
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            UIManager.Score++;
        }
    }
}
