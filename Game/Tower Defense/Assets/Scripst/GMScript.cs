using UnityEngine;

public class GMScript : MonoBehaviour
{
    public GameObject GOUI;
    public GameObject PlayerUI;
    public static bool gameOver = false;
    private void Update()
    {
        if (gameOver)
        {
            return;
        }
        if (PlayerStats.Lives <= 0 || Input.GetKey(KeyCode.Space))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameOver = true;
        PlayerUI.SetActive(false);
        GOUI.SetActive(true);
        Debug.Log("poner Fin");
    }
}
