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

    public GameObject powerupscrpt;

    public GameObject P2firstHealth;
    public GameObject P2secondHealth;
    public GameObject P2thirdHealth;

    private HealthBar P1heart1;
    private HealthBar P1heart2;
    private HealthBar P1heart3;

    private HealthBar P2heart1;
    private HealthBar P2heart2;
    private HealthBar P2heart3;

    bool dead;
    // bool shieldUP = false;
    PowerUps powerUps;

    void Start()
    {
        P1heart1 = P1firstHealth.GetComponent<HealthBar>();
        P1heart2 = P1secondHealth.GetComponent<HealthBar>();
        P1heart3 = P1thirdHealth.GetComponent<HealthBar>();

        P2heart1 = P2firstHealth.GetComponent<HealthBar>();
        P2heart2 = P2secondHealth.GetComponent<HealthBar>();
        P2heart3 = P2thirdHealth.GetComponent<HealthBar>();

        powerUps = powerupscrpt.GetComponent<PowerUps>();

        Debug.Log(powerUps.healthsys);

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
    

        /*if (!dead &&firstScript.healthEmpty && secondScript.healthEmpty && thirdScript.healthEmpty == true)
        {
            dead = true;
            Debug.Log("The player has died");

        }*/
    }

    public void P1LoseHealth()
    {
        //  && !powerUps.healthsys
        if(powerUps.healthsys) {
            Debug.Log("This is shield's status");
            Debug.Log(powerUps.healthsys);
        }
        if (!P1heart1.healthEmpty && powerUps.healthsys)
        {
            P1heart1.HealthLost();
        }
        else if (!P1heart2.healthEmpty && powerUps.healthsys)
        {
            P1heart2.HealthLost();
        }
        else if (!P1heart3.healthEmpty && powerUps.healthsys)
        {
            P1heart3.HealthLost();
        }
    }

    public void P2LoseHealth()
    {
        if (!P2heart1.healthEmpty)
        {
            P2heart1.HealthLost();
        }
        else if (!P2heart2.healthEmpty)
        {
            P2heart2.HealthLost();
        }
        else if (!P2heart3.healthEmpty)
        {
            P2heart3.HealthLost();
        }
    }
    public void P1DoubleLoseHealth()
    {
        for (int i = 0; i < 2; i++)
        {
            P1LoseHealth();
        }
    }
    public void P2DoubleLoseHealth()
    {
        for (int i = 0; i < 2; i++)
        {
            P2LoseHealth();
        }
    }

    void AddHealth()
    {
        if (P1heart3.healthEmpty==true)
        {
            P1heart3.AddHealth();
        }
        else if (P1heart2.healthEmpty==true)
        {
            P1heart2.AddHealth();
        }
        else if (P1heart1.healthEmpty==true)
        {
            P1heart1.AddHealth();
        }
    }
}