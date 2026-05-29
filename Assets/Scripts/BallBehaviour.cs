using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class BallBehaviour : MonoBehaviour
{
    public Camera mainCam;

    public GameObject objectSpawner;
    public Transform PlayerOne; //this is the player 1 game object that the ball will follow
    public Transform PlayerTwo; //and this is the player 2 object.

    public float BallSpeed = 5f; //the base/original speed of the ball
    public float BallSpeedLimit = 15.0f; //the limit for the ball's speed
    public float BonusBallSpeed; //the speed of the ball during a speed bonus power up

    public int playerTurn;
    public PlayerMovements movementScript;
    public PlayerBehaviour FirstPlayer; //the variable for accessing player 1
    public PlayerBehaviour SecondPlayer; //and this is for player 2

    public GameObject HealthBarSystem;
    public HealthBarSystem HBS;

    public bool isInput;// diable whether the player can click the mouse again or not
    public bool P1ballonDDMG;// use to call when the ball is on double dmg or not
    public bool P2ballonDDMG;
    public bool speedBonusStatus; //used to tell the ball whether the speed bonus is active or not

    public GameObject parryText;
    public GameObject missedText;

    public Animator animSpeed;

    public Animator player1animator;
    public Animator player2animator;
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
        if (collisioninfo.tag == "Parry")
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



        // hit codes
        if (collisioninfo.tag == "Heart")
        {
            if (playerTurn == 1)
            {
                if (!FirstPlayer.isShield)
                {
                    if (P2ballonDDMG)
                    {
                        HBS.P1DoubleLoseHealth();

                        BallSpeed = 5f;
                        animSpeed.speed = 1f;

                        FirstPlayer.DmgAudio();
                        FirstPlayer.playerHealth -= 2;

                        StartCoroutine(HitFlash(FirstPlayer.playerSprite));
                        StartCoroutine(CheckHealth());
                    }
                    else
                    {
                        Debug.Log("Player 1 got hit");

                        HBS.P1LoseHealth();

                        BallSpeed = 5f;
                        animSpeed.speed = 1f;

                        FirstPlayer.DmgAudio();
                        FirstPlayer.playerHealth -= 1;

                        StartCoroutine(HitFlash(FirstPlayer.playerSprite));
                        StartCoroutine(CheckHealth());
                    }
                }
                else
                {
                    Debug.Log("Player 1 blocked with shield");
                    FirstPlayer.isShield = false;
                }

                // Always switch target/turn
                playerTurn = 2;
            }

            else if (playerTurn == 2)
            {
                if (!SecondPlayer.isShield)
                {
                    if (P1ballonDDMG)
                    {
                        HBS.P2DoubleLoseHealth();
                        BallSpeed = 5f;
                        animSpeed.speed = 1f;
                        SecondPlayer.DmgAudio();
                        SecondPlayer.playerHealth -= 2;
                        StartCoroutine(HitFlash(SecondPlayer.playerSprite));
                        StartCoroutine(CheckHealth());
                    }
                    else
                    {
                        Debug.Log("Player 2 got hit");

                        HBS.P2LoseHealth();
                        BallSpeed = 5f;
                        animSpeed.speed = 1f;
                        SecondPlayer.DmgAudio();
                        SecondPlayer.playerHealth -= 1;
                        StartCoroutine(HitFlash(SecondPlayer.playerSprite));
                        StartCoroutine(CheckHealth());
                    }

                  
                }
                else
                {
                    Debug.Log("Shield blocked damage");
                    SecondPlayer.isShield = false;
                }

                // Always switch target
                playerTurn = 1;
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
    /*public void CheckHealth()
    {
        if (FirstPlayer.playerHealth <= 0)
        {
            FirstPlayer.playerAnim.SetBool("isDead", true);
            SceneManager.LoadScene(5);
        }

        if (SecondPlayer.playerHealth <= 0)
        {
            SecondPlayer.playerAnim.SetBool("isDead", true);
            SceneManager.LoadScene(4);
        }

    }*/
    // Update is called once per frame
    void Update()
    {
        //if it's player 1's turn to play, the ball will move towards player 1
        if (playerTurn == 1)
        {
            if (speedBonusStatus != true)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                PlayerOne.position,
                BallSpeed * Time.deltaTime
                );
            }
            else
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                PlayerOne.position,
                BonusBallSpeed * Time.deltaTime
                );
            }

            Vector3 direction = PlayerOne.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
        }

        //if it's player 2's turn to play, the ball will move towards player 2
        if (playerTurn == 2)
        {
            if (speedBonusStatus != true)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                PlayerTwo.position,
                BallSpeed * Time.deltaTime
                );
            }
            else
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                PlayerTwo.position,
                BonusBallSpeed * Time.deltaTime
                );
            }

            Vector3 direction = PlayerTwo.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
        }

       
        if (Input.GetKeyDown(KeyCode.F) && isInput == true && playerTurn == 1)
        {
            player1animator.SetBool("isHitting", true);

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
                    P2ballonDDMG = false;
                }



                if (BallSpeed < BallSpeedLimit)
                {
                    if (speedBonusStatus != true)
                    {
                        BallSpeed++;
                    }
                    animSpeed.speed++;
                }
                else if (BallSpeed >= BallSpeedLimit)
                {
                    BallSpeed = BallSpeedLimit;
                }

                Debug.Log("Player 1 Parried");
                FirstPlayer.SwipeAudio();
                FirstPlayer.HitAudio();
                FirstPlayer.PrintingTextTR(parryText);
            }
            else
            {
                //playerTurn = 2;
                Debug.Log("Player 1 Missed");
                isInput = false;
                FirstPlayer.DDMGeffect = false;
                FirstPlayer.SwipeAudio();
                FirstPlayer.MissAudio();
                FirstPlayer.PrintingTextTR(missedText);

            }

        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            player1animator.SetBool("isHitting", false);
        }
        // Player 2 turn
         if (Input.GetKeyDown(KeyCode.RightControl) && isInput == true && playerTurn == 2)
        {
            player2animator.SetBool("isHitting", true);
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
                    P1ballonDDMG = false;
                }

                if (BallSpeed < BallSpeedLimit)
                {
                    if (speedBonusStatus != true)
                    {
                        BallSpeed++;
                    }
                    animSpeed.speed++;
                }
                else if (BallSpeed >= BallSpeedLimit)
                {
                    BallSpeed = BallSpeedLimit;
                }

                Debug.Log("Player 2 Parried");
                SecondPlayer.SwipeAudio();
                SecondPlayer.HitAudio();
                SecondPlayer.PrintingTextTL(parryText);
            }
            else
            {
                //playerTurn = 1;
                Debug.Log("Player 2 Missed");
                isInput = false;
                SecondPlayer.DDMGeffect = false;
                SecondPlayer.SwipeAudio();
                SecondPlayer.MissAudio();
                SecondPlayer.PrintingTextTL(missedText);
            }
        }
        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            player2animator.SetBool("isHitting", false);
        }

    }
    public IEnumerator HitFlash(SpriteRenderer sr)
    {
        for (int i = 0; i < 6; i++)
        {
            sr.enabled = false;

            yield return new WaitForSeconds(0.1f);

            sr.enabled = true;

            yield return new WaitForSeconds(0.1f);
        }
    }



    public IEnumerator CheckHealth()
    {
        if (FirstPlayer.playerHealth <= 0)
        {
            movementScript.canMove = false;
            BallSpeed = 0;
            FirstPlayer.playerAnim.SetBool("isDead", true);
            Destroy(objectSpawner);
           

            yield return StartCoroutine(DeathCameraFocus(FirstPlayer.transform));

            SceneManager.LoadScene(5);
        }

        if (SecondPlayer.playerHealth <= 0)
        {
            movementScript.canMove = false;
            BallSpeed = 0;
            SecondPlayer.playerAnim.SetBool("isDead", true);
            Destroy(objectSpawner);
            yield return StartCoroutine(DeathCameraFocus(SecondPlayer.transform));

            SceneManager.LoadScene(4);
        }
    }

    IEnumerator DeathCameraFocus(Transform target)
    {
        Vector3 startPos = mainCam.transform.position;

        Vector3 targetPos = new Vector3(
            target.position.x,
            target.position.y,
            startPos.z
        );

        float startSize = mainCam.orthographicSize;
        float targetSize = 3f;

        float duration = 2f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;

            mainCam.transform.position =
                Vector3.Lerp(startPos, targetPos, time / duration);

            mainCam.orthographicSize =
                Mathf.Lerp(startSize, targetSize, time / duration);

            yield return null;
        }

        yield return new WaitForSeconds(1f);
    }
}
