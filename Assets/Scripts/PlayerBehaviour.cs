using System.Collections;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //public float PlayerSpeed = 7f;
    public bool parryPermission; //used by the ball to decide which player can parry
    public bool playerTurn;
    public bool isInside;
    public bool isHit;

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


}
