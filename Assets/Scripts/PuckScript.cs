using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuckScript : MonoBehaviour
{
    public ScoreScript ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    public float MaxSpeed;

    public AudioManager audioManager;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if(other.tag == "AiGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.PlayerScore);
                WasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(false));
            }else if(other.tag =="PlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.AiScore);
                WasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(true));
            }else if(other.tag == "Goal")
            {
                WasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(true));
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioManager.PlayPuckCollision();
    }

    private IEnumerator ResetPuck(bool didAiScore)
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = !this.gameObject.GetComponent<SpriteRenderer>().enabled;
        rb.velocity = rb.position = new Vector2(0, 0);
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = !this.gameObject.GetComponent<SpriteRenderer>().enabled;

        if (didAiScore)
        {
            rb.position = new Vector2(0, -1);
        }
        else
        {
            rb.position = new Vector2(0, 1);
        }
    }

    public void CenterPuck()
    {
        rb.position = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }
    
}
