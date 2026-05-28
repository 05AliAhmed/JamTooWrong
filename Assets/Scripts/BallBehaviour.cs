using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public Transform PlayerOne; //this is the player 1 game object that the ball will follow
    public Transform PlayerTwo; //and this is the player 2 object.

    public float BallSpeed = 5f; //the base/original speed of the ball
    public float BallSpeedLimit = 15.0f; //the limit for the ball's speed

    public int playerTurn;

    public PlayerBehaviour FirstPlayer; //the variable for accessing player 1
    public PlayerBehaviour SecondPlayer; //and this is for player 2

    public GameObject HealthBarSystem;
    public HealthBarSystem HBS;

    public bool isInput;// diable whether the player can click the mouse again or not
    public bool P1ballonDDMG;// use to call when the ball is on double dmg or not
    public bool P2ballonDDMG;

    public GameObject parryText;
    public GameObject missedText;

   
    //public GameObject parryText;
   // public bool isInside;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        playerTurn = 1; //this means the ball will approach player 1 at the beginning of the game
        isInput = true;
        P1ballonDDMG = false;
        P2ballonDDMG = false;
    }

    //this function checks if the ball is in the parry zone
     void OnTriggerEnter2D(Collider2D collisioninfo)
    {
        if (collisioninfo.tag == "Player")
        {
            Debug.Log("Inside");
            

        }

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

        /*if (playerTurn == 1)
        {
            FirstPlayer.parryPermission = true;
            SecondPlayer.parryPermission = false;
        }

        if (playerTurn == 2)
        {
            SecondPlayer.parryPermission = true;
            FirstPlayer.parryPermission = false;
        }*/
        if (collisioninfo.tag == "Heart")
        {
            if (playerTurn == 1)
            {
                if (P2ballonDDMG)
                {
                    HBS.P1DoubleLoseHealth();
                    playerTurn = 2;

                    BallSpeed = 5f;
                }
                else
                {
                    Debug.Log("Player 1 got hit");
                    HBS.P1LoseHealth();
                    //FirstPlayer.isHit = true;
                    playerTurn = 2;

                    BallSpeed = 5f;
                }
            }

            else if (playerTurn == 2)
            {
                if (P1ballonDDMG)
                {
                    HBS.P2DoubleLoseHealth();
                    playerTurn = 1;

                    BallSpeed = 5f;
                }
                else
                {
                    Debug.Log("Player 2 got hit");
                    HBS.P2LoseHealth();
                    //SecondPlayer.isHit = true;
                    playerTurn = 1;

                    BallSpeed = 5f;
                }

            }
        }
    }

    //this code tells the game that the ball left the parry zone
    private void OnTriggerExit2D(Collider2D collision)
    {
        //this simply means both players aren't able to parry as soon as the ball leaves the parry zone
        SecondPlayer.parryPermission = false;
        FirstPlayer.parryPermission = false;
      
        isInput = true;

        

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
        /*if (Input.GetMouseButtonDown(2)) //feel free to replace input with whatever you want
         {
             //if player one can parry, move the ball towards player two, and increase it's speed.
             if (FirstPlayer.parryPermission == true)
             {
                 playerTurn++;
                 if (BallSpeed < BallSpeedLimit) 
                 { 
                     BallSpeed++;
                 }
             }

             //if player two can parry, move the ball towards player one, and increase it's speed.
             if (SecondPlayer.parryPermission == true)
             {
                 playerTurn++;
                 if (BallSpeed < BallSpeedLimit)
                 {
                     BallSpeed++;
                 }
             }
             if (FirstPlayer.parryPermission==false )
             {
                 playerTurn++;
                 Debug.Log("Misclick");
             }
             if (SecondPlayer.parryPermission==false)
             {
                 playerTurn++;
                 Debug.Log("Misclick");
             }
         }
        */
        if (Input.GetMouseButtonDown(0)&&isInput==true)
        {
            // Player 1 turn
            if (playerTurn == 1)
            {
                if (FirstPlayer.parryPermission)
                {
                    playerTurn = 2;
                    transform.position += (PlayerTwo.position - transform.position).normalized * 0.5f;
                    if (FirstPlayer.DDMGeffect == true)
                    {
                        P1ballonDDMG = true;
                        FirstPlayer.DDMGeffect = false;
                    }

                    if (P2ballonDDMG)
                    {
                        P2ballonDDMG= false;
                    }



                    if (BallSpeed < BallSpeedLimit)
                    {
                        BallSpeed++;
                    }
                    else if (BallSpeed >= BallSpeedLimit)
                    {
                        BallSpeed=BallSpeedLimit;
                    }

                    Debug.Log("Player 1 Parried");
                    FirstPlayer.PrintingTextTR(parryText);
                }
                else
                {
                    //playerTurn = 2;
                    Debug.Log("Player 1 Missed");
                    isInput =false;
                    FirstPlayer.DDMGeffect=false;
                    FirstPlayer.PrintingTextTR(missedText);
                
                }
            }

            // Player 2 turn
            else if (playerTurn == 2)
            {
                if (SecondPlayer.parryPermission)
                {
                 
                    playerTurn = 1;
                    transform.position += (PlayerOne.position - transform.position).normalized * 0.5f;
                    if (SecondPlayer.DDMGeffect == true)
                    {
                        P2ballonDDMG = true;
                        SecondPlayer.DDMGeffect = false;
                    }
                    if (P1ballonDDMG)
                    {
                        P1ballonDDMG= false;
                    }

                    if (BallSpeed < BallSpeedLimit)
                    {
                        BallSpeed++;
                    }
                    else if (BallSpeed >= BallSpeedLimit)
                    {
                        BallSpeed = BallSpeedLimit;
                    }

                    Debug.Log("Player 2 Parried");
                    SecondPlayer.PrintingTextTL(parryText);
                }
                else
                {
                    //playerTurn = 1;
                    Debug.Log("Player 2 Missed");
                    isInput = false;
                    SecondPlayer.DDMGeffect=false;
                    SecondPlayer.PrintingTextTL(missedText);
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
