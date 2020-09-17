using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;
    Vector2 direction;
    float radius;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized; // direction (1,1)
        radius = transform.localScale.x / 2; //half the width
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        //Bounce off top and bottom
        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }
        // game winner
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            Debug.Log("Right Player Wins");
            
            
        }
        if (transform.position.x > GameManager.bottomLeft.x - radius && direction.x > 0)
        {
            Debug.Log("Left Player Wins");
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<Paddle> ().isRight;
            // if hitting right paddle moving towards right flipping direction
            if (isRight == true && direction.x > 0) {
                direction.x = -direction.x;
            }
            // if hitting left paddle moving towards left flip direction
            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }


        }
    }

}
