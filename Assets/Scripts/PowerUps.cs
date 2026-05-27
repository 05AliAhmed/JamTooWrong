using Unity.VisualScripting;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collisioninfo)
    {
        if (collisioninfo.tag == "Player")
        {
            Debug.Log("Player contact the power up");
            Destroy(gameObject);
        }
    }
}
