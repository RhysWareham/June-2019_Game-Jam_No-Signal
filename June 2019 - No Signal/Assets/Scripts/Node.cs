using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Node : MonoBehaviour {

    //Image and Button Component
    [SerializeField]
    private Button button;
    [SerializeField]
    private Image image;

    public NodeGenerator parent;

    //ENUM FOR TYPE
    public enum NodeType
    {
        Grass,
        Town,
        Cave,
        Ruins,
        Forest
    }

    //Array of images
    [SerializeField]
    private Sprite[] nodeImages;


    public string teleportRoom { private set; get; }
    public NodeType type;

    //Node Type Room
    private Dictionary<NodeType, string> roomDictonary = new Dictionary<NodeType, string>()
    {
        {NodeType.Grass, "Enemies Attack"},
        {NodeType.Town, "Town"},
        {NodeType.Cave, "CaveRuins"},
        {NodeType.Ruins, "Enemies Attack"},
        {NodeType.Forest, "Enemies Attack"}
    };

    //Optimal Frequebcy Dictonary
    private Dictionary<NodeType, int> frequencyDictonary = new Dictionary<NodeType, int>()
    {
        {NodeType.Grass, 500},
        {NodeType.Town, 200},
        {NodeType.Cave, 900},
        {NodeType.Ruins, 777},
        {NodeType.Forest, 29}
    };

    //Node Image Dictonary
    private Dictionary<NodeType, Sprite> imageDictonary = new Dictionary<NodeType, Sprite>();

    //Frequency Range
    private float possibleFreqVariation = 90f;
    private float optimalFreq = 20f;
    private float freqRange = 200f;
    private float currentSliderFreq = 0f;

    private void Awake()
    {
        imageDictonary.Add(NodeType.Grass, nodeImages[2]);
        imageDictonary.Add(NodeType.Town, nodeImages[3]);
        imageDictonary.Add(NodeType.Cave, nodeImages[4]);
        imageDictonary.Add(NodeType.Ruins, nodeImages[5]);
        imageDictonary.Add(NodeType.Forest, nodeImages[6]);
    }

    public void Setup()
    {
        //Set Frequency base of type plus random variation
        teleportRoom = roomDictonary[type];
        optimalFreq = frequencyDictonary[type] + Random.Range(-possibleFreqVariation, possibleFreqVariation);
        image.sprite = imageDictonary[type];
    }

    private void Update()
    {
        currentSliderFreq = parent.GetCurrentfreq();

        if ((currentSliderFreq < (optimalFreq - freqRange)) || (currentSliderFreq > (optimalFreq + freqRange)))
        {
            image.color = new Color(1, 1, 1, 0);
        }
        else
        {
            image.color = new Color(1, 1, 1, 1);
        }

        //Disable/Enable Button
        if(image.color.a < 0.2f)
        {
            button.enabled = false;
        }
        else
        {
            button.enabled = true;
        }
    }

    /// <summary>
    /// Teleport to given room
    /// </summary>
    public void Teleport()
    {
        Rememberer.roomToRememeber = teleportRoom;
        SceneManager.LoadScene("VanMiniGame");
    }
}
