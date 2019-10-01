using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f;

    [SerializeField]
    private GameObject player;

    private Vector2 midPointTarget;

    private Vector2 finalPosition;

    private Vector3 startPos;

    private bool isActive = false;

    private void OnEnable()
    {
        PlayerMovement.usedRadio += PlayerUsedRadio;
    }

    private void OnDisable()
    {
        PlayerMovement.usedRadio += PlayerUsedRadio;
    }

    private void Start()
    {
        finalPosition = GenerateNewPosition();
        midPointTarget = finalPosition;
        startPos = player.transform.position;
    }

    void Update ()
    {
		if(isActive)
        {
            this.transform.position = MoveTo(player.transform.position);
        }
        else
        {
            if(this.transform.position == (Vector3)finalPosition)
            {
                finalPosition = GenerateNewPosition();

                int i = 0;
                while(!PathCheck(this.transform.position, finalPosition))
                {
                    finalPosition = GenerateNewPosition();
                    i++;
                    if(i > 10)
                    {
                        break;
                    }
                }
            }
            this.transform.position = MoveTo(finalPosition);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            if(!collision.gameObject.GetComponent<PlayerMovement>().isPaused)
            {
                SceneManager.LoadScene("GrassLands");
            }
        }
    }

    private Vector2 GenerateNewPosition()
    {
        Vector2 newPos = new Vector2(this.transform.position.x, this.transform.position.y) + Random.insideUnitCircle;

        if(newPos.y > 5.0f)
        {
            newPos.y = 5.0f;
        }
        else if(newPos.y < -5.0f)
        {
            newPos.y = -5.0f;
        }

        if(newPos.x > 10.0f)
        {
            newPos.x = 10.0f;
        }
        else if(newPos.x < -10.0f)
        {
            newPos.x = -10.0f;
        }

        return newPos;
    }

    private Vector2 MoveTo(Vector2 target)
    {
        return Vector2.MoveTowards(this.transform.position, target, moveSpeed * Time.deltaTime);
    }

    private bool PathCheck(Vector2 currPos, Vector2 endPos)
    {
        RaycastHit2D hit = Physics2D.Linecast(currPos, endPos);
        if (Physics2D.Linecast(currPos, endPos))
        {
            Vector2 raycastDir = hit.point - (Vector2)transform.position;

            if (Physics2D.Raycast(hit.point, raycastDir))
            {
                return false;
            }
        }

        return true;
    }

    private void RadioTrigger()
    {
        isActive = !isActive;
    }

    private void PlayerUsedRadio()
    {
        isActive = !isActive;
    }
}
