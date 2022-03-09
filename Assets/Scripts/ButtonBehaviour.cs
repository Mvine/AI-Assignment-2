using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class ButtonBehaviour : MonoBehaviour
{

    public enum State { Empty, X, O };

    [SerializeField]
    private GameManager gameManager;

    public State state = State.Empty;

    private TextMeshProUGUI tmp;

    void Start()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
    }


    public void SetText()
    {
        if (state != State.Empty) { return; }

        if (gameManager.turn == GameManager.Turn.Player)
        {
            tmp.text = "X";
            gameManager.turn = GameManager.Turn.AI;
        }

        if (gameManager.turn == GameManager.Turn.AI)
        {
            tmp.text = "O";
            gameManager.turn = GameManager.Turn.Player;
        }

    }
}
