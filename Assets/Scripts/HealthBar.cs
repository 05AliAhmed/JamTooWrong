using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public SpriteRenderer health;
    public Sprite healthLost;
    public Sprite healthRegain;
    public bool healthEmpty=false;
    public Animator healthanim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health =GetComponent<SpriteRenderer>();
        //healthanim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HealthLost()
    {
        health.sprite = healthLost;
        healthEmpty = true;
        healthanim.SetBool("isAnimating",true);
        //heathanim.enabled = true;
    }
    public void AddHealth()
    {
        health.sprite = healthRegain;
        healthEmpty =false;
        healthanim.SetBool("isAnimating", false);
    }
}
