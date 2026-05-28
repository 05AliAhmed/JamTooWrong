using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerups;
    //public SpriteRenderer sr;
    public float cooldown =8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown-=Time.deltaTime;   
        }
        else if(cooldown <= 0)
        {
            cooldown = 8f;
            SpawnObject();
        }
        
           
        
    }

    public void SpawnObject()
    {
        // Random screen position
        float randomX = Random.Range(100f, Screen.width-100f);
        float randomY = Random.Range(100f, Screen.height-100f);

        // Convert screen position to world position
        Vector2 screenPos = new Vector2(randomX, randomY);

        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        Instantiate(powerups, worldPos, Quaternion.identity);
    }



}
