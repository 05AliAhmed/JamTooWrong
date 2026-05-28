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
    public bool isInside;
    public bool isHit;
    public bool isMissed;

    //public BallBehaviour ball;
   // public GameObject missedText;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //everything below issthe player movement code. replace this, if you want to.
        /*float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;

        transform.position += (Vector3)(movement * PlayerSpeed * Time.deltaTime);*/
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
}
