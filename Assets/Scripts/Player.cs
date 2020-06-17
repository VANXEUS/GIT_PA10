using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rb;
    public Transform Obstacle;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.AddForce(Vector3.up * 160);
        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -10f, 3.7f), transform.position.z);

        if(transform.position.y <= -9)
        {
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            SceneManager.LoadScene("GameOver");
        }
    }
}
