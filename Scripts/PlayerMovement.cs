using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f;

    private Rigidbody rb;

    public float shiftSpeed = 17f;
    
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


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = shiftSpeed;
        }
        else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)){
            speed = 40f;
        }
        else{
            speed = 0f;
        }

        if (Input.GetKey(KeyCode.F)) {
            speed = 10f;
        }
    }

    public IEnumerator ScoreChange(){
        yield return new WaitForSeconds(waittime);
        if (intscore >= maxtime) {
            WinText.SetActive(true);
            score = 100;
            
        }
        if (speed == 0) {
            score += 0;
            intscore = (int) score;
            ScoreText.text = "Score: " + intscore.ToString();
        }
        else if (speed > 0){
            score += Time.deltaTime * 3;
            intscore = (int) score;
            ScoreText.text = "Score: " + intscore.ToString();
        }
    }
}
