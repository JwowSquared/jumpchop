using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HouseController : MonoBehaviour
{
    public Text woodDisplay;

    private void Start()
    {
        woodDisplay.text = "Total Wood: " + StateNameController.wood.ToString();
    }
    public void GoOutside ()
    {
        SceneManager.LoadScene("Outside");
    }
}
