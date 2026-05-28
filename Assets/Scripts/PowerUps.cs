using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public PlayerBehaviour player;
    public List<GameObject> groupOfPlayers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        groupOfPlayers = GameObject.FindGameObjectsWithTag("Player").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collisioninfo)
    {
        /*if (collisioninfo.tag == "Player")
        {
            player.DDMGeffect = true;
            Debug.Log("Player contact the power up");
            Destroy(gameObject);
        }*/
        if (collisioninfo.tag == "Player")
        {
            if (groupOfPlayers.Contains(collisioninfo.gameObject))
            {
                Debug.Log("Player contact the power up");
                Debug.Log("it is found");

                collisioninfo.GetComponent<PlayerBehaviour>().DDMGeffect = true;


                
                Destroy(gameObject);
            }
        }
    }
}
