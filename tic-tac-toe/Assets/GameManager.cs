using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Button[] buttons;
    public TextMeshProUGUI resultText;

    private string currentPlayer;
    private int moveCount;

    void Start()
    {
        currentPlayer = "X";
        moveCount = 0;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
            int index = i;  // Capture the index for the delegate
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    void OnButtonClick(int index)
    {
        if (buttons[index].GetComponentInChildren<TextMeshProUGUI>().text == "")
        {
            buttons[index].GetComponentInChildren<TextMeshProUGUI>().text = currentPlayer;
            moveCount++;
            if (CheckWin())
            {
                resultText.text = currentPlayer + " wins!";
                EndGame();
            }
            else if (moveCount == 9)
            {
                resultText.text = "It's a draw!";
                EndGame();
            }
            else
            {
                currentPlayer = (currentPlayer == "X") ? "O" : "X";
            }
        }
    }

    bool CheckWin()
    {
        string[,] board = new string[3, 3];
        for (int i = 0; i < buttons.Length; i++)
        {
            board[i / 3, i % 3] = buttons[i].GetComponentInChildren<TextMeshProUGUI>().text;
        }

        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                return true;
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                return true;
        }

        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            return true;
        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            return true;

        return false;
    }

    void EndGame()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }
}
