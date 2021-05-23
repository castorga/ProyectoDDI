using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshPro score;
    // Update is called once per frame
    void Update()
    {
        score.SetText(PlayerScore.score.ToString());
    }
}
