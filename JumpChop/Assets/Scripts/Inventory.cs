using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int numWood;
    private Text output;

    // Start is called before the first frame update
    void Start()
    {
        numWood = 0;
        output = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        output.text = "WOOD: " + numWood;
    }
}
