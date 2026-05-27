using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public Transform PlayerOne; //this is the player 1 game object that the ball will follow
    public Transform PlayerTwo; //and this is the player 2 object.

    public float BallSpeed = 5f; //the base/original speed of the ball
    public float BallSpeedLimit = 25.0f; //the limit for the ball's speed

    public int playerTurn;

    public PlayerBehaviour FirstPlayer; //the variable for accessing player 1
    public PlayerBehaviour SecondPlayer; //and this is for player 2

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTurn = 1; //this means the ball will approach player 1 at the beginning of the game
    }

    //this function checks if the ball is in the parry zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Inside");

        if (playerTurn == 1)
        {
            FirstPlayer.parryPermission = true;
            SecondPlayer.parryPermission = false;
        }

        if (playerTurn == 2)
        {
            SecondPlayer.parryPermission = true;
            FirstPlayer.parryPermission = false;
        }
    }

    //this code tells the game that the ball left the parry zone
    private void OnTriggerExit2D(Collider2D collision)
    {
        //this simply means both players aren't able to parry as soon as the ball leaves the parry zone
        SecondPlayer.parryPermission = false;
        FirstPlayer.parryPermission = false;
    }
    // Update is called once per frame
    void Update()
    {
        //if it's player 1's turn to play, the ball will move towards player 1
        if (playerTurn == 1)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                PlayerOne.position,
                BallSpeed * Time.deltaTime
                );
        }

        //if it's player 2's turn to play, the ball will move towards player 2
        if (playerTurn == 2)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                PlayerTwo.position,
                BallSpeed * Time.deltaTime
                );
        }

        //if you press this button, you will attempt to parry
        if (Input.GetMouseButtonDown(0)) //feel free to replace input with whatever you want
        {
            //if player one can parry, move the ball towards player two, and increase it's speed.
            if (FirstPlayer.parryPermission != false)
            {
                playerTurn++;
                if (BallSpeed < BallSpeedLimit) 
                { 
                    BallSpeed++;
                }
            }

            //if player two can parry, move the ball towards player one, and increase it's speed.
            if (SecondPlayer.parryPermission != false)
            {
                playerTurn++;
                if (BallSpeed < BallSpeedLimit)
                {
                    BallSpeed++;
                }
            }

        }

        //this code makes sure player turns are cycled between player 1 and 2 by setting playerTurn back to 1 every time its more than 2,
        //creating a loop that makes switching player turns as easy as "playerTurn++;".
        if (playerTurn > 2)
        {
            playerTurn = 1;
        }
    }
}
