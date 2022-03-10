using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float playerSpeed = 5f;

    private GameManager gameManager;
    public bool isGameActive;


    private void Start()
    {
        isGameActive = true;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerScaling();

    }

    // moving the player
    void PlayerMovement()
    {
        transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
    }


    // scaling the player game object
    private void PlayerScaling()
    {
        while (isGameActive) {
            Vector3 firstScale = new Vector3(0.2f, 0.34f, 1.55f);
            Vector3 secondScale = new Vector3(0.2f, 1f, 0.2f);
            float time = 0.1f;


            if (Input.GetKey(KeyCode.Mouse0))
            {
                Debug.Log("left key");
                transform.localScale = Vector3.Lerp(transform.localScale, firstScale, time * Time.deltaTime);
                Debug.Log("left key down");
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                Debug.Log("right key");
                transform.localScale = Vector3.Lerp(transform.localScale, secondScale, time * Time.deltaTime);
                Debug.Log("right key down");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            gameManager.UpdateScore(5);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("destorier"))
        {

            //Debug.Log("is destory");
            gameManager.GameOver();
            isGameActive = false;
            Destroy(gameObject);
            //Destroy(collision.gameObject);
            
        }
    }
}
