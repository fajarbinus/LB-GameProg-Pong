using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    private float rand;
   
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall",2f);
    }

    void GoBall()
    {
        rand = Random.Range(0,2);
        if (rand == 0) rb2d.AddForce(new Vector2(20,-15));
        else rb2d.AddForce(new Vector2(-20,-15));
    }

    public void RestartGame()
    {
        //Debug.Log("Restart!!!");
        ResetBall();
        Invoke("GoBall",2f);
        wallCollisionCount = 0;
    }
    private void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    private int wallCollisionCount;
    [SerializeField] Vector2 myVel;


    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "King") //jika terkena player
        {
            //Debug.Log("King Punch!");
            //rb2d.AddForce(new Vector2(20,-15));
            wallCollisionCount = 0;
            DirectionChecker(coll.gameObject.transform);
            if (isPositiveDirection) rb2d.AddForce(new Vector2(20,15));
            else rb2d.AddForce(new Vector2(20,-15));
        }
        else if (coll.gameObject.name == "Pig") //jika terkena enemy
        {
            //Debug.Log("Pig Punch!");
            //rb2d.AddForce(new Vector2(-20,-15));
            wallCollisionCount = 0;
            DirectionChecker(coll.gameObject.transform);
            if (isPositiveDirection) rb2d.AddForce(new Vector2(-20,15));
            else rb2d.AddForce(new Vector2(-20,-15));
        }
        else //jika terkena wall
        {
            wallCollisionCount = wallCollisionCount + 1;
            //Debug.Log("Wall Collision! = " + wallCollisionCount);
            if (wallCollisionCount > 6) GoBall();
        }
    }
    
    
    #region PlayerDirectionChecker
        Vector3 previousPosition;
        [SerializeField]bool isPositiveDirection;
        void DirectionChecker(Transform transform)
        {
        Vector2 currentPosition = transform.transform.position;
        
            if (currentPosition.y > previousPosition.y)
            {
                isPositiveDirection = true;
            }
            else if (currentPosition.y < previousPosition.y)
            {
                isPositiveDirection = false;
            }
            previousPosition = currentPosition;
        }
    #endregion


    void Update()
    {
        
    }

}
