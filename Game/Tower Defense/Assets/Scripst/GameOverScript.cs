using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text Waves;
    public GameObject PlayerUI;
    public GameObject ShopUI;
    private void OnEnable()
    {
        PlayerUI.SetActive(false);
        ShopUI.SetActive(false);
        Waves.text = (WaveScript.wave).ToString();
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
