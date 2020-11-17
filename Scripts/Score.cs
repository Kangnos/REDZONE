using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score;
    public int intscore;
    public float waittime; // this variable num should match with spawnwait variable in GameManager script. 
    public Text ScoreText;
    public GameObject WinText;
    public GameObject Player;
    public int maxtime;


    void Awake(){
        score = 0;
        intscore = 0;
    }

    void Update()
    {
        StartCoroutine(ScoreChange());
    }

    public IEnumerator ScoreChange(){
        yield return new WaitForSeconds(waittime);
        score += Time.deltaTime * 3;
        intscore = (int) score;
        ScoreText.text = "Score: " + intscore.ToString();

        if (intscore >= maxtime) {
            WinText.SetActive(true);
        }
    }
}
