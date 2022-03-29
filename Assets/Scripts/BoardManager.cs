using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoardManager : MonoBehaviour
{

    [SerializeField]
    public List<ButtonBehaviour> buttons;

    [SerializeField]
    public GameObject restartButton;

    // Start is called before the first frame update
    void Start()
    {
        //disabling the restart game button
        restartButton.SetActive(false);
    }

    //freeze all board actions
    public void FreezeBoard()
    {
        foreach (ButtonBehaviour button in buttons)
        {
            button.gameObject.GetComponent<Button>().enabled = false;

        }
    }

    public bool CheckSolved()
    {

        bool filled = true;

        //if there is an empty square then the board is not filled
        foreach (ButtonBehaviour button in buttons)
        {
            if (button.state == ButtonBehaviour.State.Empty)
            {
                filled = false;
            }
        }

        //check if X wins
        if (CheckWinner(ButtonBehaviour.State.X))
        {
            FreezeBoard();
            GameManager.turn = GameManager.Turn.None;

            restartButton.GetComponentInChildren<TextMeshProUGUI>().text = "X wins";
            restartButton.SetActive(true);
            return true;
        }

        //check if O wins
        else if (CheckWinner(ButtonBehaviour.State.O))
        {
            FreezeBoard();
            GameManager.turn = GameManager.Turn.None;

            restartButton.GetComponentInChildren<TextMeshProUGUI>().text = "O wins";
            restartButton.SetActive(true);
            return true;
        }

        else if (filled)
        {
            restartButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cat Game";
            restartButton.SetActive(true);
            return true;
        }

        return filled;

    }

    bool CheckWinner(ButtonBehaviour.State played)
    {
        //checking all the possible win states of the board
        if ((buttons[0].state == played && buttons[1].state == played && buttons[2].state == played) ||
            (buttons[0].state == played && buttons[4].state == played && buttons[8].state == played) ||
            (buttons[0].state == played && buttons[3].state == played && buttons[6].state == played) ||
            (buttons[1].state == played && buttons[4].state == played && buttons[7].state == played) ||
            (buttons[2].state == played && buttons[5].state == played && buttons[8].state == played) ||
            (buttons[2].state == played && buttons[4].state == played && buttons[6].state == played) ||
            (buttons[3].state == played && buttons[4].state == played && buttons[5].state == played) ||
            (buttons[6].state == played && buttons[7].state == played && buttons[8].state == played))
        {
            //disabling all of the buttons when the game is over
            foreach (ButtonBehaviour button in buttons)
            {
                button.gameObject.GetComponent<Button>().enabled = false;
                GameManager.turn = GameManager.Turn.None;
            }

            return true;

        }
        else
        {
            return false;
        }
    }
}
