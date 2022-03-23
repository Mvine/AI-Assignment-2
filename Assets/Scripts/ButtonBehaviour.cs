using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ButtonBehaviour : MonoBehaviour
{

    public enum State { Empty, X, O };

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private PlayerBehaviour player;
    
    [SerializeField]
    private AIBehaviour AI;

    public State state = State.Empty;

    private TextMeshProUGUI tmp;

    private Button button;

    void Start()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponent<Button>();
    }


    public void SetText()
    {
        if (GameManager.turn == GameManager.Turn.Player)
        {
            tmp.text = PlayerBehaviour.playerSymbol;
            if(PlayerBehaviour.playerSymbol ==  "X")
            {
                state = ButtonBehaviour.State.X;
            }
             if(PlayerBehaviour.playerSymbol ==  "O")
            {
                state = ButtonBehaviour.State.O;
            }

            GameManager.turn = GameManager.Turn.AI;

            AI.AIMove();

        }

         else if (GameManager.turn == GameManager.Turn.AI)
         {
             tmp.text = AIBehaviour.AISymbol;
             GameManager.turn = GameManager.Turn.Player;
             if(AIBehaviour.AISymbol ==  "X")
             {
                 state = ButtonBehaviour.State.X;
             }
              if(AIBehaviour.AISymbol ==  "O")
             {
                 state = ButtonBehaviour.State.O;
             }
         }

        button.enabled= false;

    }
}
