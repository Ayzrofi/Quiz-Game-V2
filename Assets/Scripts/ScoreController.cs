using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    public static int TheScore;
    public Text ScoreText;

    private void Start()
    {
        if (ScoreText != null)
        {
            ScoreText.text = TheScore.ToString();
        }
    }

}
