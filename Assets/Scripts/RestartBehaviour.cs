using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBehaviour : MonoBehaviour
{

    public void restartGame()
    {
        SceneManager.LoadScene("PlayerSelect");
    }
}
