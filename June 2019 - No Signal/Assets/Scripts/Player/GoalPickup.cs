using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPickup : MonoBehaviour
{
    public GameObject van;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            van.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
            
        }
    }
}
