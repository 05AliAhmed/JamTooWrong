using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    //public float PlayerSpeed = 7f;
    public bool parryPermission; //used by the ball to decide which player can parry
    public bool playerTurn;
   //public int playerHealth = 3;
    public bool isDead;
    public bool DDMGeffect;
    public int MaxHealth = 3;
    public int playerHealth;

    public AudioSource hitaudio;


    //public BallBehaviour ball;
    // public GameObject missedText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitaudio.Stop();
        isDead = false;
        DDMGeffect = false;
         playerHealth = MaxHealth;
}

    // Update is called once per frame
    void Update()
    {
       
        if (!isDead&&playerHealth<=0)
            
        {
            isDead = true;
            Debug.Log("Game Over");
            //SceneManager.LoadScene(0);
        }
    }



    public IEnumerator PrintTextTL(GameObject text)
    {
        GameObject spawnedText = Instantiate(
            text,
            gameObject.transform.position + new Vector3(-1f, 1f, 0f),
            Quaternion.identity
        );

        yield return new WaitForSeconds(1f);

        Destroy(spawnedText);
    }
    public void PrintingTextTL(GameObject text)
    {
        StartCoroutine(PrintTextTL(text));
    }

    public IEnumerator PrintTextTR(GameObject text)
    {
        GameObject spawnedText = Instantiate(
            text,
            gameObject.transform.position + new Vector3(1f, 1f, 0f),
            Quaternion.identity
        );

        yield return new WaitForSeconds(1f);

        Destroy(spawnedText);
    }
    public void PrintingTextTR(GameObject text)
    {
        StartCoroutine(PrintTextTR(text));
    }

    public void HitAudio()
    {
        hitaudio.Play();
    }
}
