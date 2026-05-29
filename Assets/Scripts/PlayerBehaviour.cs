using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject Shield;
    public SpriteRenderer playerSprite;
    //public float PlayerSpeed = 7f;
    public bool parryPermission; //used by the ball to decide which player can parry
    public bool playerTurn;
   //public int playerHealth = 3;
    public bool isDead;
    public bool isFirstDead;
    public bool isSecondDead;
    public bool isShield = false;

    public bool DDMGeffect;
    public int MaxHealth = 3;
    public int playerHealth;

    public AudioSource dmgAudio;
    public AudioSource missedAudio;
    public AudioSource hitAudio;
    public AudioSource swipeAudio;

    public Animator playerAnim;
    //public BallBehaviour ball;
    // public GameObject missedText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Shield.SetActive(false);
        dmgAudio.Stop();
        missedAudio.Stop();
        hitAudio.Stop();
        swipeAudio.Stop();
        //isDead = false;
        isFirstDead = false;
        isSecondDead = false;
        DDMGeffect = false;
         playerHealth = MaxHealth;
}

    // Update is called once per frame
    void Update()
    {
        if (isShield)
        {
            Shield.SetActive(true);
        }
        else if (!isShield)
        {
            Shield.SetActive(false);
        }
       
        /*if (!isDead&&playerHealth<=0)
            
        {
            isDead = true;
            playerAnim.SetBool("isDead", true);
            Debug.Log("Game Over");

            if (isFirstDead)
            {
                SceneManager.LoadScene(4);
            }
            if (isSecondDead)
            {
                SceneManager.LoadScene(5);
            }
            //SceneManager.LoadScene(0);
        }*/
    }



    public IEnumerator PrintTextTL(GameObject text)
    {
        GameObject spawnedText = Instantiate(
            text,
            gameObject.transform.position + new Vector3(-1f, 1f, 0f),
            Quaternion.Euler(0f, 0f, 25f)
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
            Quaternion.Euler(0f, 0f, -25f)
        );

        yield return new WaitForSeconds(1f);

        Destroy(spawnedText);
    }
    public void PrintingTextTR(GameObject text)
    {
        StartCoroutine(PrintTextTR(text));
    }

    public void DmgAudio()
    {
        dmgAudio.Play();
    }

    public void MissAudio()
    {
        missedAudio.Play();
    }
    public void HitAudio()
    {
        hitAudio.Play();
    }
    public void SwipeAudio()
    {
        swipeAudio.Play();
    }
}
