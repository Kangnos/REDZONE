using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

    public float MaxHealth = 1f;
    private float currentHealth;
    public bool isDead = false;
    bool damaged;
    public GameObject EndText;

    public Slider HealthSlider;

    public Image damagedImage;
    public Color flashColor = new Color(1f, 0f, 0.1f);
	public float flashspeed = 5f;

    public GameObject DeadImage;




	// Use this for initialization
	void Awake () {
        currentHealth = MaxHealth;
	}

	private void Update()
	{
        if(damaged)
        {
            damagedImage.color = flashColor;
        }
        else
        {
            damagedImage.color = Color.Lerp(damagedImage.color, Color.clear, flashspeed * Time.deltaTime);
        }
        damaged = false;
	}

	// Update is called once per frame
	public void TakeDamage (float amount) {
        currentHealth -= amount;

        damaged = true;

        HealthSlider.value = currentHealth;


        if(currentHealth <= 0f && !isDead)
        {
            
			// T.T It must be die.........
			OnDeath();
            isDead = true;
        }
	}


    void OnDeath()
    {
        DeadImage.SetActive(true);
        gameObject.SetActive(false); 
        EndText.SetActive(true);

        //Debug.Log("You Die..zzz");

    }
}
