using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public SpriteRenderer health;
    public Sprite healthLost;
    public Sprite healthRegain;
    public bool healthEmpty=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health =GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HealthLost()
    {
        health.sprite = healthLost;
        healthEmpty = true;
    }
    public void AddHealth()
    {
        health.sprite = healthRegain;
        healthEmpty =false;
    }
}
