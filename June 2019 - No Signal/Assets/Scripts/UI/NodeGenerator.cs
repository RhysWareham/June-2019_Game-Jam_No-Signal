using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeGenerator : MonoBehaviour {

    [SerializeField]
    private Slider freqSlider;

    [SerializeField]
    private GameObject nodePrefab, mapBackground;
    private int nodeCountToGenerate = 2;

    [SerializeField]
    private Vector2 rectConfines = new Vector2();

    [SerializeField]
    private Node.NodeType typeToGen;


    // Use this for initialization
    void Start() {

        for (int i = 0; i < nodeCountToGenerate; ++i)
        {
            GameObject node = Instantiate(nodePrefab);
            node.transform.SetParent(transform);

            //Gen Rand Pos
            Vector2 pos = UnityEngine.Random.insideUnitCircle * 180;
            
            node.GetComponent<RectTransform>().localPosition = new Vector3(pos.x, pos.y, 0);


            //Generate node type
            //Node.NodeType[] nodeTypes = new Node.NodeType[] { Node.NodeType.Grass, Node.NodeType.Town, Node.NodeType.Cave, Node.NodeType.Ruins, Node.NodeType.Forest };
            //int index = UnityEngine.Random.Range(0, nodeTypes.Length);
            node.GetComponent<Node>().type = typeToGen;
            node.GetComponent<Node>().parent = this;
            node.GetComponent<Node>().Setup();
        }

    }

    public float GetCurrentfreq()
    {
        return freqSlider.value;
    }
}
