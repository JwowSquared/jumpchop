using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayTimer : MonoBehaviour
{

    public float timer;
    private Text output;
    // Start is called before the first frame update
    void Start()
    {
        timer = 10f;
        output = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            SceneManager.LoadScene("Inside");
        }
        else
        {
            output.text = Mathf.FloorToInt(timer).ToString();
            timer -= Time.deltaTime;
        }
    }
}
