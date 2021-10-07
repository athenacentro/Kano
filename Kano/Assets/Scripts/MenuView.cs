using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuView : MonoBehaviour
{
    public void OnClickNarwhal()
    {
        SceneManager.LoadScene("NarwhalMigration");
    }
}
