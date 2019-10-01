using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;

    private Vector3 movementVector = new Vector3();

    public bool isRadioActive = false;

    public bool isPaused = false;

    public delegate void useRadio();

    public static useRadio usedRadio;

    public Vector3 startPos;

    private GameObject goal;
    float distanceToGoal;

    [SerializeField]
    private GameObject radioLight;
    [SerializeField]
    private GameObject radioLightOff;
    private float lightTimerOn = 1.0f;

    [SerializeField]
    private AudioSource radioAudioSource;

    [SerializeField]
    private Animator playerAnimatior;

    public int clickCount = 0;

    private float time = 0f;


    private void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Goal");
    }


    void Update()
    {

        if (!isPaused)
        {
            movementVector = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                movementVector.y += moveSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                movementVector.y -= moveSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                movementVector.x -= moveSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                movementVector.x += moveSpeed * Time.deltaTime;
            }

            //Animation state controller
            if (movementVector != Vector3.zero)
            {
                playerAnimatior.SetBool("Walking", true);
            }
            else
            {
                playerAnimatior.SetBool("Walking", false);
            }

            if (GameObject.FindGameObjectsWithTag("Tutorial").Length > 0 && clickCount < 3)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    clickCount++;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    isRadioActive = !isRadioActive;

                    radioLight.SetActive(false);
                    radioLightOff.SetActive(true);

                    if (usedRadio != null)
                    {
                        usedRadio();
                    }
                }
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Not much difference in beep delay after you move a few metres away from goal

            if(!goal.activeSelf)
            {
                goal = GameObject.FindGameObjectWithTag("Van");
            }

            if (isRadioActive && radioLight != null && goal != null)
            {
                //distanceToGoal = scan();

                //lightTimerOn += distanceToGoal * Time.deltaTime;

                //if (lightTimerOn >= distanceToGoal)
                //{
                //    radioLightOff.SetActive(!radioLightOff.activeSelf);
                //    radioLight.SetActive(!radioLight.activeSelf);

                //    lightTimerOn = 1.0f;

                //    if (radioLight.activeSelf && radioAudioSource.time < (radioAudioSource.clip.length * 0.1f))
                //    {
                //        radioAudioSource.PlayOneShot(radioAudioSource.clip);
                //    }
                //}


                if(time < 0)
                {
                    time = scan();
                    radioLightOff.SetActive(!radioLightOff.activeSelf);
                    radioLight.SetActive(!radioLight.activeSelf);

                    if (radioLight.activeSelf && radioAudioSource.time < (radioAudioSource.clip.length * 0.1f))
                    {
                        radioAudioSource.PlayOneShot(radioAudioSource.clip);
                    }
                }

                time -= Time.deltaTime;
            }

            Debug.Log(time);

            transform.position += movementVector;
        }
    }

    public void EnterPause()
    {
        isPaused = !isPaused;
    }

    private float scan()
    {
        
        return Mathf.Clamp((Mathf.Pow(Vector2.Distance(this.transform.position, goal.transform.position), 2) * .005f), 0.07f, Mathf.Infinity);

    }
}
