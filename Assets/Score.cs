using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scoreText;
    public  int score;
    public Score Instance;
    public static int ChildDeathCount;
    public GameObject GameWon;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        if(Instance == null)
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ObjectsScore.scoreObject.ToString();
        if(score > 25000)
        {
            GameWon.SetActive(true);    
        }


    }
    public void UpdateText()
    {
        
        score += 100;
        scoreText.text = score.ToString();
    }
    public void UpdateChild()
    {
        score += 500;
        scoreText.text = score.ToString();
    }
    public void UpdateAi()
    {
        score += 1000;
        scoreText.text = score.ToString();
    }
}
