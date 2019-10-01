using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAlienScript : MonoBehaviour
{
    [SerializeField]
    private GameObject textBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            textBox.SetActive(true);
            //gameObject.GetComponent<AudioSource>().time = 0;
            if (gameObject.GetComponent<AudioSource>() != null)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            textBox.SetActive(false);
            if (gameObject.GetComponent<AudioSource>() != null)
            {
                gameObject.GetComponent<AudioSource>().Stop();
            }
        }
    }
}
