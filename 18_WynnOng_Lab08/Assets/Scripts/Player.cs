using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public Text scoretext;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

      
        if (transform.position.y >= 3.95f)
        {
            transform.position = new Vector3(transform.position.x, 3.95f, transform.position.z);
        }

        if (transform.position.y <= -3.95f)
        {
            transform.position = new Vector3(transform.position.x, -3.95f, transform.position.z);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.tag == "Score")
        {
            score++;
            scoretext.text = "Score: " + score;
        }
    }
}
