using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int MoneyCounter = 0;
    public TMP_Text MoneyText;
    public Menu menu;
    private void Start()
    {
        MoneyCounter = PlayerPrefs.GetInt("Money");
        MoneyText.text = MoneyCounter.ToString();
    }
    public void MoneyAdd()
    {
        MoneyCounter++;
        MoneyText.text = MoneyCounter.ToString();
    }
    public void GameOver()
    {
        menu.GameOver();
        PlayerPrefs.SetInt("Money", MoneyCounter);
    }
}