using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEnemyTeleport : MonoBehaviour {

    [SerializeField]
    private GameObject teleport;

    private GameObject player;
    private bool teleported = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !teleported)
        {
            player = collision.gameObject;
            player.GetComponent<PlayerMovement>().isPaused = true;
            StartCoroutine(LoadLevel());
        }
    }

    /// <summary>
    /// Loads level
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadLevel()
    {
        teleported = true;
        player.GetComponent<Animator>().SetTrigger("Teleport");
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene("GrassLands");
    }


}
