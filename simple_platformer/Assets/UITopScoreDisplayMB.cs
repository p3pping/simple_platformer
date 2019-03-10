using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UITopScoreDisplayMB : MonoBehaviour
{
    public int numScoresToDisplay = 5;

    // Start is called before the first frame update
    void Start()
    {
        if(AppStateManager.Instance.GetCurrentState() is GameOverState)
        {
            GameOverState state = AppStateManager.Instance.GetCurrentState() as GameOverState;
            var scores = state.GetTopNScores(numScoresToDisplay);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Top Scores");
            
            foreach(Score score in scores)
            {
                sb.AppendLine(String.Format("{0}  -  {1}", score.Name, score.FinalScore));
            }

            GetComponent<Text>().text = sb.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
