using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{

    [SerializeField]
    public List<ButtonBehaviour> buttons;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckSolved()
    {
        ButtonBehaviour.State played;

        if(PlayerBehaviour.playerSymbol == "X")
        {
            played = ButtonBehaviour.State.X;
        }
        else
        {
            played = ButtonBehaviour.State.O;
        }


        if ((buttons[0].state == played && buttons[1].state == played && buttons[2].state == played) ||
            (buttons[0].state == played && buttons[4].state == played && buttons[8].state == played) ||
            (buttons[0].state == played && buttons[3].state == played && buttons[6].state == played) ||
            (buttons[1].state == played && buttons[4].state == played && buttons[7].state == played) ||
            (buttons[2].state == played && buttons[5].state == played && buttons[8].state == played) ||
            (buttons[2].state == played && buttons[4].state == played && buttons[6].state == played) ||
            (buttons[3].state == played && buttons[4].state == played && buttons[5].state == played) ||
            (buttons[6].state == played && buttons[7].state == played && buttons[8].state == played))
        {
            foreach (ButtonBehaviour button in buttons)
            {
                button.gameObject.GetComponent<Button>().enabled = false;
                GameManager.turn = GameManager.Turn.None;
            }

            Debug.Log("Player wins");
        }
        else
        {
            Debug.Log("nobody wins");
            //return false;
        }

    }

}
