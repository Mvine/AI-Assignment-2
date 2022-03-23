using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{

    public static string AISymbol = "O";

    [SerializeField]
    private BoardManager boardManager;





    // Start is called before the first frame update
    void Start()
    {
        AIMove();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AIMove()
    {
        if (GameManager.turn == GameManager.Turn.AI)
        {

            //AI logic goes here

            int randomSpot = returnEmpty();
            boardManager.buttons[randomSpot].SetText();

            Debug.Log(randomSpot);

        }

        GameManager.turn = GameManager.Turn.Player;
    }

    private int returnEmpty()
    {
        int randomSpot = Random.Range(0, 9);

            if (boardManager.buttons[randomSpot].state == ButtonBehaviour.State.Empty)
            {
                return randomSpot;
            }
            else
            {
                Debug.Log("false");
                return returnEmpty();
            }
    }
}
