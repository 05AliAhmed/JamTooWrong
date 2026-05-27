using UnityEngine;

public class HealthBarSystem : MonoBehaviour
{
    public GameObject firstHealth;
    public GameObject secondHealth;
    public GameObject thirdHealth;

    private HealthBar firstScript;
    private HealthBar secondScript;
    private HealthBar thirdScript;

    void Start()
    {
        firstScript = firstHealth.GetComponent<HealthBar>();
        secondScript = secondHealth.GetComponent<HealthBar>();
        thirdScript = thirdHealth.GetComponent<HealthBar>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoseHealth();
        }
        if (Input.GetMouseButtonDown(1))
        {
            AddHealth();
        }
    }

    void LoseHealth()
    {
        if (!firstScript.healthEmpty)
        {
            firstScript.HealthLost();
        }
        else if (!secondScript.healthEmpty)
        {
            secondScript.HealthLost();
        }
        else if (!thirdScript.healthEmpty)
        {
            thirdScript.HealthLost();
        }
    }
    void AddHealth()
    {
        if (thirdScript.healthEmpty==true)
        {
            thirdScript.AddHealth();
        }
        else if (secondScript.healthEmpty==true)
        {
            secondScript.AddHealth();
        }
        else if (firstScript.healthEmpty==true)
        {
            firstScript.AddHealth();
        }
    }
}