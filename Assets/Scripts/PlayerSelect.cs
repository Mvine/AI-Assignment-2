using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{

    [SerializeField]
    private bool isX;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setPlayerSymbol()
    {
        if(isX)
        {
            PlayerBehaviour.playerSymbol = "X";
            AIBehaviour.AISymbol = "O";
            GameManager.turn = GameManager.Turn.Player;
            SceneManager.LoadScene("Game");

        }

        else
        {
            PlayerBehaviour.playerSymbol = "O";
            AIBehaviour.AISymbol = "X";
            GameManager.turn = GameManager.Turn.AI;
            SceneManager.LoadScene("Game");
        }
        

    }
}
