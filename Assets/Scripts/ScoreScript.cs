using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public GameObject DeathObject;
    public GameObject myscoreTextObject;
    public GameObject WinObject;

    public Text Highscore;
    public Text myscoreText;
    public Text DeathScore;

    public Text ScoreWin;

    public int ScoreNumber;
    public int highscore = 0;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("HIGHscore", 0);
        ScoreNumber = 0;
        myscoreText.text = "Score : " + ScoreNumber;
        
        DeathScore.text = "Score : " + ScoreNumber;
        Highscore.text = "HIGHSCORE : " + highscore;

        ScoreWin.text = "Score is " + ScoreNumber;

        DeathObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D Star)
    {
        if(Star.tag == "Star")
        {
            ScoreNumber += 2;
            Destroy(Star.gameObject);
            myscoreText.text = "Score : " + ScoreNumber;
            DeathScore.text = "Score is " + ScoreNumber;
            Highscore.text = "HIGHSCORE : " + highscore;
            ScoreWin.text = "Score is " + ScoreNumber;
            if (highscore < ScoreNumber)
            {
                PlayerPrefs.SetInt("HIGHscore", ScoreNumber);
            }
        }

        if(player.IsDead)
        {
            myscoreTextObject.SetActive(false);
            DeathObject.SetActive(true);
        }

        if(player.Won)
        {
            WinObject.SetActive(true);
            myscoreTextObject.SetActive(false);
        }

    }
}
