using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    public async void AIMove()
    {
        if (GameManager.turn == GameManager.Turn.AI)
        {

            //AI logic goes here

            //int randomSpot = ReturnEmpty();
            //boardManager.buttons[randomSpot].SetText();


            float bestScore = -Mathf.Infinity;
            int bestMove = 0;

            for (int i = 0; i < boardManager.buttons.Count  ; i++)
            {
                if (boardManager.buttons[i].state == ButtonBehaviour.State.Empty)
                {
                    if (AISymbol == "X")
                    {
                        boardManager.buttons[i].state = ButtonBehaviour.State.X;
                        float score = Minimax(boardManager.buttons, 0, false);
                        boardManager.buttons[i].state = ButtonBehaviour.State.Empty;

                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove = i;
                        }
                        else if (score == bestScore && Random.Range(0, 2) == 1)
                        {
                            bestScore = score;
                            bestMove = i;

                        }
                    }

                    if (AISymbol == "O")
                    {
                        boardManager.buttons[i].state = ButtonBehaviour.State.O;
                        float score = Minimax(boardManager.buttons, 0, false);
                        boardManager.buttons[i].state = ButtonBehaviour.State.Empty;

                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove = i;
                        }
                        else if (score == bestScore && Random.Range(0, 2) == 1)
                        {
                            bestScore = score;
                            bestMove = i;

                        }
                    }

                }
            }

            if (AISymbol == "O")
            {
                boardManager.buttons[bestMove].state = ButtonBehaviour.State.O;
                Button button = boardManager.buttons[bestMove].gameObject.GetComponent<Button>();
                button.enabled = false;
                button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = AISymbol;

            }

            if (AISymbol == "X")
            {
                boardManager.buttons[bestMove].state = ButtonBehaviour.State.X;
                Button button = boardManager.buttons[bestMove].gameObject.GetComponent<Button>();
                button.enabled = false;
                button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = AISymbol;
            }

            GameManager.turn = GameManager.Turn.Player;

        }

    }

    private int ReturnEmpty()
    {
        int randomSpot = Random.Range(0, 9);

        if (boardManager.buttons[randomSpot].state == ButtonBehaviour.State.Empty)
        {
            return randomSpot;
        }
        else
        {
            Debug.Log("false");
            return ReturnEmpty();
        }
    }

    float Minimax(List<ButtonBehaviour> buttons, int depth, bool isMaximizer)
    {
        if (AISymbol == "O")
        {
            if (CheckWinner(ButtonBehaviour.State.O))
            {
                return 1;
            }
            if (CheckWinner(ButtonBehaviour.State.X))
            {
                return -1;
            }
            if (CheckFull())
            {
                return 0;
            }
        }

        if (AISymbol == "X")
        {
            if (CheckWinner(ButtonBehaviour.State.X))
            {
                return 1;
            }
            if (CheckWinner(ButtonBehaviour.State.O))
            {
                return -1;
            }
            if (CheckFull())
            {
                return 0;
            }
        }

        if (isMaximizer)
        {
            float bestScore = -Mathf.Infinity;
            foreach (ButtonBehaviour button in boardManager.buttons)
            {
                if (button.state == ButtonBehaviour.State.Empty)
                {
                    if (AISymbol == "X")
                    {
                        button.state = ButtonBehaviour.State.X;
                        float score = Minimax(buttons, depth + 1, false);
                        button.state = ButtonBehaviour.State.Empty;
                        bestScore = Mathf.Max(score, bestScore);
                    }

                    if (AISymbol == "O")
                    {
                        button.state = ButtonBehaviour.State.O;
                        float score = Minimax(buttons, depth + 1, false);
                        button.state = ButtonBehaviour.State.Empty;
                        bestScore = Mathf.Max(score, bestScore);
                    }
                }

            }

            return bestScore;
        }
        else
        {
            float bestScore = Mathf.Infinity;
            foreach (ButtonBehaviour button in boardManager.buttons)
            {
                if (button.state == ButtonBehaviour.State.Empty)
                {
                    if (AISymbol == "X")
                    {
                        button.state = ButtonBehaviour.State.O;
                        float score = Minimax(buttons, depth + 1, true);
                        button.state = ButtonBehaviour.State.Empty;
                        bestScore = Mathf.Min(score, bestScore);
                    }

                    if (AISymbol == "O")
                    {
                        button.state = ButtonBehaviour.State.X;
                        float score = Minimax(buttons, depth + 1, true);
                        button.state = ButtonBehaviour.State.Empty;
                        bestScore = Mathf.Min(score, bestScore);
                    }
                }

            }

            return bestScore;
        }


    }

    bool CheckWinner(ButtonBehaviour.State letter)
    {
        return (boardManager.buttons[0].state == letter && boardManager.buttons[1].state == letter && boardManager.buttons[2].state == letter) ||
            (boardManager.buttons[0].state == letter && boardManager.buttons[4].state == letter && boardManager.buttons[8].state == letter) ||
            (boardManager.buttons[0].state == letter && boardManager.buttons[3].state == letter && boardManager.buttons[6].state == letter) ||
            (boardManager.buttons[1].state == letter && boardManager.buttons[4].state == letter && boardManager.buttons[7].state == letter) ||
            (boardManager.buttons[2].state == letter && boardManager.buttons[5].state == letter && boardManager.buttons[8].state == letter) ||
            (boardManager.buttons[2].state == letter && boardManager.buttons[4].state == letter && boardManager.buttons[6].state == letter) ||
            (boardManager.buttons[3].state == letter && boardManager.buttons[4].state == letter && boardManager.buttons[5].state == letter) ||
            (boardManager.buttons[6].state == letter && boardManager.buttons[7].state == letter && boardManager.buttons[8].state == letter);
    }

    bool CheckFull()
    {
        foreach (ButtonBehaviour button in boardManager.buttons)
        {
            if (button.state == ButtonBehaviour.State.Empty)
            {
                return false;
            }
        }

        return true;
    }

}
