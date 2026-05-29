using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    //public float PlayerSpeed = 7f;
    public bool parryPermission; //used by the ball to decide which player can parry
    public bool playerTurn;
   //public int playerHealth = 3;
    public bool isDead;
    public bool DDMGeffect;
    public int MaxHealth = 3;
    public int playerHealth;

    // public GameObject player1;
    // public GameObject player2;

    public AudioSource dmgAudio;
    public AudioSource missedAudio;
    public AudioSource hitAudio;
    public AudioSource swipeAudio;

    public Animator playerAnim;

    public float deathAnimationtime;
    //public BallBehaviour ball;
    // public GameObject missedText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dmgAudio.Stop();
        missedAudio.Stop();
        hitAudio.Stop();
        swipeAudio.Stop();
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
            playerAnim.SetBool("isDead", true);
            StartCoroutine(playerDestroy());
            // gameObject.SetActive(false);
            // Destroy(player1);
            Debug.Log("Game Over");
            Debug.Log("first me");
            //SceneManager.LoadScene(0);
        }
    }

    public IEnumerator playerDestroy()
    {
        Debug.Log("second me");
        yield return new WaitForSeconds(deathAnimationtime);
        Debug.Log("third me");
        gameObject.SetActive(false);
        // Destroy(gameObject);
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
