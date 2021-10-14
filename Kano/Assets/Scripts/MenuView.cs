using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuView : MonoBehaviour
{
    public void OnClickNarwhal()
    {
        SceneManager.LoadScene("NarwhalHelp");
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("NarwhalMigration");
    }
}
