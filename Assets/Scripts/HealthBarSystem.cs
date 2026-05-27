using UnityEngine;

public class HealthBarSystem : MonoBehaviour
{
    public GameObject firstHealth;
    public GameObject secondHealth;
    public GameObject thirdHealth;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnMouseDown();
    }
    void OnClick()
    {

    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Object clicked");
        }
       
    }
}
