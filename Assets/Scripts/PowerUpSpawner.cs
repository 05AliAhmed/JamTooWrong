using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerups;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        // Random screen position
        float randomX = Random.Range(0f, Screen.width/2);
        float randomY = Random.Range(0f, Screen.height);

        // Convert screen position to world position
        Vector2 screenPos = new Vector2(randomX, randomY);

        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        Instantiate(powerups, worldPos, Quaternion.identity);
    }
}
