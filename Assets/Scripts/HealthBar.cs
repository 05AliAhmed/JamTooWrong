using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public SpriteRenderer health;
    public Sprite healthLost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health =GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
