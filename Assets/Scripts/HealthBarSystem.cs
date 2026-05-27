using UnityEngine;

public class HealthBarSystem : MonoBehaviour
{
    //public GameObject firstPlayer;
    //public GameObject secondPlayer;
    //public  PlayerBehaviour firstPlayerS;
   // public PlayerBehaviour secondPlayerS;


    public GameObject P1firstHealth;
    public GameObject P1secondHealth;
    public GameObject P1thirdHealth;

    public GameObject P2firstHealth;
    public GameObject P2secondHealth;
    public GameObject P2thirdHealth;

    private HealthBar P1firstScript;
    private HealthBar P1secondScript;
    private HealthBar P1thirdScript;

    private HealthBar P2firstScript;
    private HealthBar P2secondScript;
    private HealthBar P2thirdScript;

    bool dead;

    void Start()
    {
        P1firstScript = P1firstHealth.GetComponent<HealthBar>();
        P1secondScript = P1secondHealth.GetComponent<HealthBar>();
        P1thirdScript = P1thirdHealth.GetComponent<HealthBar>();

        P2firstScript = P2firstHealth.GetComponent<HealthBar>();
        P2secondScript = P2secondHealth.GetComponent<HealthBar>();
        P2thirdScript = P2thirdHealth.GetComponent<HealthBar>();

        //firstPlayerS = firstPlayer.GetComponent<PlayerBehaviour>();
        //secondPlayerS = secondPlayer.GetComponent<PlayerBehaviour>();
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
       /* if(firstPlayerS.isHit==true)
        {
            Debug.Log("kk");
            P1LoseHealth();
            firstPlayerS.isHit = false;
        }
        if (secondPlayerS.isHit == true)
        {
            Debug.Log("GG");
            P2LoseHealth();
            secondPlayerS.isHit = false;
        }*/
        if (Input.GetMouseButtonDown(1))
      
        {
            AddHealth();
        }

        /*if (!dead &&firstScript.healthEmpty && secondScript.healthEmpty && thirdScript.healthEmpty == true)
        {
            dead = true;
            Debug.Log("The player has died");

        }*/
    }

    public void P1LoseHealth()
    {
        if (!P1firstScript.healthEmpty)
        {
            P1firstScript.HealthLost();
        }
        else if (!P1secondScript.healthEmpty)
        {
            P1secondScript.HealthLost();
        }
        else if (!P1thirdScript.healthEmpty)
        {
            P1thirdScript.HealthLost();
        }
    }

    public void P2LoseHealth()
    {
        if (!P2firstScript.healthEmpty)
        {
            P2firstScript.HealthLost();
        }
        else if (!P2secondScript.healthEmpty)
        {
            P2secondScript.HealthLost();
        }
        else if (!P2thirdScript.healthEmpty)
        {
            P2thirdScript.HealthLost();
        }
    }
    public void DoubleLoseHealth()
    {
        for (int i = 0; i < 2; i++)
        {
            P1LoseHealth();
        }
    }

    void AddHealth()
    {
        if (P1thirdScript.healthEmpty==true)
        {
            P1thirdScript.AddHealth();
        }
        else if (P1secondScript.healthEmpty==true)
        {
            P1secondScript.AddHealth();
        }
        else if (P1firstScript.healthEmpty==true)
        {
            P1firstScript.AddHealth();
        }
    }
}