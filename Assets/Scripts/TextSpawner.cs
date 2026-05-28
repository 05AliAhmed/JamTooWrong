using System.Collections;
using UnityEngine;

public class TextSpawner : MonoBehaviour
{
    public GameObject DDMGtext;
    public GameObject SPEEDtext;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DDMGtext.SetActive(false);
        SPEEDtext.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
    public IEnumerator DDMGText()
    {
        DDMGtext.SetActive(true);
        yield return new WaitForSeconds(2);

       
     
        
        DDMGtext.SetActive(false);
    }
    public IEnumerator SPEEDText()
    {
        {
            SPEEDtext.SetActive(true);
            yield return new WaitForSeconds(2);


            SPEEDtext.SetActive(false);
        }
    }
}
