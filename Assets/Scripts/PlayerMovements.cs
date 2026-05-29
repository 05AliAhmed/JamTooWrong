// using System.Numerics;
// using System.Numerics;
using System.Threading;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    public float speed;
    public bool canMove=true;
    void PlayerOneMovement()
    {
        
        // float moveX = Input.GetAxis("Horizontal"); // move on x axis, if A -1 if D 1
        // float moveY = Input.GetAxis("Vertical");// move on y axis, if W -1 if S 1

        float moveX = 0f;
        float moveY = 0f;

        if(Input.GetKey(KeyCode.W)) moveY = 1f;
        if(Input.GetKey(KeyCode.S)) moveY = -1f;
        if(Input.GetKey(KeyCode.D)) moveX = 1f;
        if(Input.GetKey(KeyCode.A)) moveX = -1f; 

        Vector3 movement = new Vector3(moveX, moveY, 0);
        playerOne.transform.Translate(movement * speed * Time.deltaTime); 
    }

    void PlayerTwoMovement()
    {
        float move2X = 0f;
        float move2Y = 0f;

        if(Input.GetKey(KeyCode.UpArrow)) move2Y = 1f;
        if(Input.GetKey(KeyCode.DownArrow)) move2Y = -1f;
        if(Input.GetKey(KeyCode.RightArrow)) move2X = 1f;
        if(Input.GetKey(KeyCode.LeftArrow)) move2X = -1f;

        Vector3 movement = new Vector3(move2X, move2Y, 0); 
        playerTwo.transform.Translate(movement * speed * Time.deltaTime);
       
    }

    void FixedUpdate()
    {
        if (!canMove) return;
        PlayerOneMovement();
        PlayerTwoMovement();
        if (playerTwo.transform.position.x < playerOne.transform.position.x)
        {
            playerTwo.GetComponent<SpriteRenderer>().flipX = false;
            playerOne.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            playerTwo.GetComponent<SpriteRenderer>().flipX = true;
            playerOne.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
