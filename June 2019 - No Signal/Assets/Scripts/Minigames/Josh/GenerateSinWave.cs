using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenerateSinWave : MonoBehaviour {

    [SerializeField] private GameObject SinWave;
    [SerializeField] private Vector3 WaveStartPosition;
    [SerializeField] private Slider Freq, Amp;
    private bool bFrequency = false, bAmplitude = false, bAudio = false;
    private float timeToWait = 2.25f;
    private float timeToCheck = 0.5f;
    private float returnColour = 0.099f;
    int currentInt = 0;

    [SerializeField] private GameObject g_Sprite, g_RadioText;
    private SpriteRenderer m_SpriteRenderer;
    private Text RadioText;
    Color m_NewColor, m_OldColor, m_GreenColor;


	void Start () {

        m_SpriteRenderer = g_Sprite.GetComponent<SpriteRenderer>();
        RadioText = g_RadioText.GetComponent<Text>();
        m_NewColor = Color.yellow;
        m_OldColor = Color.white;
        m_GreenColor = Color.green;

        bFrequency = false;
        bAmplitude = false;
        StartCoroutine(LoopFunction(timeToWait));
        StartCoroutine(CheckFrequency(timeToCheck));
        StartCoroutine(ResetColour(returnColour));
    }

    private IEnumerator LoopFunction(float waitTime)
    {
        // STUCK IN A LOOP
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(SinWave, WaveStartPosition, Quaternion.identity);
        }
    }

    private IEnumerator CheckFrequency(float timeToCheck)
    {
        // STUCK IN A LOOP
        while (true)
        {

            yield return new WaitForSeconds(timeToCheck);
            m_SpriteRenderer.color = m_NewColor;
            Debug.Log(Mathf.Round(JoshWave.frequency * 10) / 10 + "    " + CorrectWave.frequency);
            Debug.Log(Mathf.Round(JoshWave.amplitude * 10) / 10 + "    " + CorrectWave.amplitude);

            if (Mathf.Abs((Mathf.Round(JoshWave.frequency * 10) / 10) - CorrectWave.frequency) < 0.2f)
            {
                Freq.gameObject.SetActive(false);
                bFrequency = true;
                Debug.Log("FREQUENCY CORRECT");
            }
            if (Mathf.Abs((Mathf.Round(JoshWave.amplitude * 10) / 10) - CorrectWave.amplitude) < 0.2f)
            {
                Amp.gameObject.SetActive(false);
                bAmplitude = true;
                Debug.Log("AMPLITUDE CORRECT");
            }

        }
    }

    private IEnumerator ResetColour(float timeToReset)
    {
        // STUCK IN A LOOP
        while (true)
        {
            yield return new WaitForSeconds(timeToReset);
            m_SpriteRenderer.color = m_OldColor;
        }
    }

    // Update is called once per frame
    void Update () {

        JoshWave.frequency = Freq.value * 10;
        JoshWave.amplitude = Amp.value * 2;



        if (bAmplitude && bFrequency == true)
        {
            StartCoroutine(SceneDelay());
            RadioText.color = m_GreenColor;
            if (bAudio == false)
            {
                gameObject.GetComponent<AudioSource>().Play();
                bAudio = true;
            }
            Debug.Log("PERFECT MATCH");
        }
	}

    IEnumerator SceneDelay()
    {

        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("TutorialEnd");
    }

}
