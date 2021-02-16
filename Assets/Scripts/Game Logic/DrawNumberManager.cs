using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DrawNumberManager : MonoBehaviour
{
    public void DrawScore(int score, Transform scoreMenu, Dictionary<int, int> spritesDict, Sprite[] spritesArray)
    {
        if (score > 999) score = 999;
        for (int i = 0; i < 3; i++) 
        {
            scoreMenu.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < score.ToString().Length; i++) 
        {
            Sprite spriteOfTheNumber = spritesArray[spritesDict[score.ToString()[score.ToString().Length - 1 - i] - '0']];
            if ((score.ToString()[score.ToString().Length - 1 - i] - '0') == 1) 
            {
                scoreMenu.GetChild(i).transform.position = new Vector2(
                    scoreMenu.GetChild(i).transform.position.x + 10,
                    scoreMenu.GetChild(i).transform.position.y
                    );
            }
            scoreMenu.GetChild(i).GetComponent<Image>().sprite = spriteOfTheNumber;
            scoreMenu.GetChild(i).GetComponent<Image>().SetNativeSize();
            scoreMenu.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void DrawMoney(int score, Transform scoreMenu, Dictionary<int, int> spritesDict, Sprite[] spritesArray)
    {
        if (score > 9999) score = 9999;
        for (int i = 0; i < 4; i++) 
        {
            scoreMenu.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < score.ToString().Length; i++) 
        {
            Sprite spriteOfTheNumber = spritesArray[spritesDict[score.ToString()[score.ToString().Length - 1 - i] - '0']];
            scoreMenu.GetChild(i).GetComponent<Image>().sprite = spriteOfTheNumber;
            scoreMenu.GetChild(i).GetComponent<Image>().SetNativeSize();
            scoreMenu.GetChild(i).gameObject.SetActive(true);
        }
    }
}
