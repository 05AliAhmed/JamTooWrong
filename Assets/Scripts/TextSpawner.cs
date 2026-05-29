using System.Collections;
using UnityEngine;

public class TextSpawner : MonoBehaviour
{
    public GameObject DDMGtext;
    public GameObject SPEEDtext;
    public AudioSource audioeffect;
    public GameObject shielduptxt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioeffect.Stop();
        DDMGtext.SetActive(false);
        SPEEDtext.SetActive(false); 
        shielduptxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
    public IEnumerator DDMGText()
    {
        audioeffect.Play();
        DDMGtext.SetActive(true);
        yield return new WaitForSeconds(2);

       
     
        
        DDMGtext.SetActive(false);
    }
    public IEnumerator SPEEDText()
    {
        {
            audioeffect.Play();
            SPEEDtext.SetActive(true);
            yield return new WaitForSeconds(2);


            SPEEDtext.SetActive(false);
        }
    }

     public IEnumerator ShieldUpTxt()
     {
        audioeffect.Play();
        shielduptxt.SetActive(true);
        yield return new WaitForSeconds(2);

         shielduptxt.SetActive(false);
    }
}
