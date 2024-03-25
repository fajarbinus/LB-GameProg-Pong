using System.Collections;
using System.Collections.Generic;
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
    }
    private void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
}
