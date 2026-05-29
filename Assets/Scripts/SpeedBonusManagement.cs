using System.Collections;
using UnityEngine;

public class SpeedBonusManagement : MonoBehaviour
{
    public BallBehaviour ballBehaviourScript; //used by the ball object to reference itself in the code
    private int coroutineStep; //used to stop the coroutine from overlapping itself; using numbers as states;

    public bool isSpeedTrigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSpeedTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isSpeedTrigger) //how to start/trigger the coroutine
        {
            ballBehaviourScript.speedBonusStatus = true;
            StartSpeedBonus();
        }

        if (ballBehaviourScript.speedBonusStatus != false) //if the coroutine isn't already active...
        {
            if (coroutineStep == 0) //if the coroutine is at it's starting step/state (0)...
            {
                StartSpeedBonus(); //begin the coroutine.
            }
        }*/
        if (isSpeedTrigger)
        {
            isSpeedTrigger = false;

            ballBehaviourScript.speedBonusStatus = true;

            StartSpeedBonus();
        }
    }

    public void StartSpeedBonus()
    {
        coroutineStep = 1; //set the coroutine step/state to 1, so the game knows a coroutine just started,
        StartCoroutine(SpeedBonusCountdown()); //begin the countdown
    }

    IEnumerator SpeedBonusCountdown()
    {
        if (ballBehaviourScript.BallSpeed >= 10.0f)
        {
            ballBehaviourScript.BonusBallSpeed = ballBehaviourScript.BallSpeed * 1.50f;
        }
        else 
        {
            ballBehaviourScript.BonusBallSpeed = ballBehaviourScript.BallSpeed * 1.25f;
        }
        
        coroutineStep = 2; //set the coroutine step/state to 2, so the game knows to stop the coroutine from starting again

        yield return new WaitForSeconds(1);

        Debug.Log("1 second");

        yield return new WaitForSeconds(1);

        Debug.Log("2 seconds");

        yield return new WaitForSeconds(1);

        Debug.Log("3 seconds");

        yield return new WaitForSeconds(1);

        Debug.Log("4 seconds");

        yield return new WaitForSeconds(1);

        Debug.Log("5 seconds");

        yield return new WaitForSeconds(1);

        Debug.Log("6 seconds");

        ballBehaviourScript.speedBonusStatus = false; //tell the game the bonus period is over.
        coroutineStep = 0; //reset the coroutine step/state, so the game knows it can start a new one gain
    }
}
