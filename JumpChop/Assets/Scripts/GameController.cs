using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    #region Singleton

    public static GameController instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Text woodDisplay;
    public Text timerDisplay;

    private int wood = 0;
    private float timer = 5f;

    public void addWood(int num)
    {
        wood += num;
        woodDisplay.text = "Wood: " + wood;
    }

    private void Start()
    {
        addWood(0);
    }

    private void Update()
    {
        if (timer < 0)
        {
            StateNameController.wood += wood;
            SceneManager.LoadScene("Inside");
        }
        else
        {
            timerDisplay.text = Mathf.FloorToInt(timer).ToString();
            timer -= Time.deltaTime;
        }
    }
}
