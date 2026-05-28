using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //public PlayerBehaviour player;
    public SpeedBonusManagement sbm;
    public TextSpawner TextSpawn;
    public List<GameObject> groupOfPlayers;
    public SpriteRenderer sr;
    public bool poweruphit;


    float number;
    float cooldown = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            
        sbm = GameObject.FindGameObjectWithTag("Ball").GetComponent<SpeedBonusManagement>();
        TextSpawn= GameObject.FindGameObjectWithTag("TextSpawn").GetComponent<TextSpawner>();
        poweruphit = false;
        sr=GetComponent<SpriteRenderer>();
        groupOfPlayers = GameObject.FindGameObjectsWithTag("Player").ToList();
        randnum();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0f&&!poweruphit)
        {
            cooldown -= Time.deltaTime;
        }
        else if (cooldown <= 0f&&!poweruphit) {
            StartCoroutine(FadeSprite());
        }


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
              

                if (number == 0)
                {
                    TextSpawn.StartCoroutine(TextSpawn.DDMGText());
                    Debug.Log("DDMG effect");
                    collisioninfo.GetComponent<PlayerBehaviour>().DDMGeffect = true;
                    poweruphit = true;
                }
                else if (number == 1)
                {
                    TextSpawn.StartCoroutine(TextSpawn.SPEEDText());
                    Debug.Log("Speed boost");
                    sbm.isSpeedTrigger = true;
                }

             
                
                Destroy(gameObject);
            }
        }
    }
    IEnumerator FadeSprite()
    {
        float duration = 0.5f; // fade time
        float time = 0;

        Color startColor = sr.color;

        while (time < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, time / duration);

            sr.color = new Color(
                startColor.r,
                startColor.g,
                startColor.b,
                alpha
            );

            time += Time.deltaTime;
            yield return null;
        }

        // fully invisible
        sr.color = new Color(
            startColor.r,
            startColor.g,
            startColor.b,
            0f
        );

        Destroy(gameObject); 

    }

    public void randnum()
    {
        number = Random.Range(0, 2);
        Debug.Log(number);
    }
}
