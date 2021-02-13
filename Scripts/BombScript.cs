using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BombScript : MonoBehaviour {

    public float delay = 3f;

    float countdown;

    public ParticleSystem explosionParticle;

    public float radius = 6f;

    public float explosionForce = 800;

    public float MaxDamage = 100;

    public AudioSource bombsound;

	// Use this for initialization
	void Start () {
        countdown = delay;
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
	}

    void OnTriggerEnter(Collider other){
        Instantiate(explosionParticle, transform.position, transform.rotation);

        bombsound.Play();

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        FindObjectOfType<AudioManager>().Play("Bombing");
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(explosionForce, transform.position, radius);

            playerHealth targetHealth = targetRigidbody.GetComponent<playerHealth>();

            if (!targetHealth)
                continue;

            float damage = CalculateDamage(targetRigidbody.position);

            targetHealth.TakeDamage(damage);
        }
        Destroy(gameObject,1);

    }

    private float CalculateDamage (Vector3 targetPosition)
    {
        Vector3 explossionToTarget = targetPosition - transform.position;
        float explosionDistance = explossionToTarget.magnitude;

        float relativeDistance = (radius - explosionDistance) / radius;

        float damage = relativeDistance * MaxDamage;

        damage = Mathf.Max(0f, damage);

        return damage;
    }
}
