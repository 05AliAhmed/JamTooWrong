using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoubleDMG : MonoBehaviour
{
    //public BallBehaviour ball;
    //public HealthBarSystem HBS;
    public List<GameObject> groupOfPlayers;
    //public GameObject obj;
   // public PlayerBehaviour player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
    void Start()
    {
        groupOfPlayers = GameObject.FindGameObjectsWithTag("Player").ToList();
    }
    public void DoubleDamageEffect()
    {
        foreach (GameObject player in groupOfPlayers)
        {
            if (player.name == "P1")
            {
                player.GetComponent<PlayerBehaviour>().DDMGeffect = true;
            }
           else if (player.name == "P2")
            {
                player.GetComponent<PlayerBehaviour>().DDMGeffect = true;
            }
        }
    }
}
