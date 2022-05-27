using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{   
    public static int Money;
    public static int startingMoney = 1000;
    public static int Lives;
    public static int startingLives = 10;
    public Text moneyText;
    public Text livesText;

    private void Start()
    {
        Money = startingMoney;
        moneyText.text = "Coins: " + Money.ToString();
        Lives = startingLives;
        livesText.text = "Lives: " + Lives.ToString();
    }
    private void Update()
    {
        moneyText.text = Money.ToString();
        livesText.text = "Lives: " + Lives.ToString();
    }
    public static void UpdateLives(int live)
    {
        Lives += live;
        Lives = (int)Mathf.Clamp(Lives, 0, Mathf.Infinity);
    }
}
