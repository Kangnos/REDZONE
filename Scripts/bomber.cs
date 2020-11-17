using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomber : MonoBehaviour {

    public float speed = 7f;
    public float moveRot = 0.5f;

    private Rigidbody rb;

    private Transform tr = null;

    public GameObject Fence;

    public GameObject respawnpoint;

    public GameObject bombber;

    public float waittime;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        new WaitForSeconds(waittime);

        transform.position += new Vector3 (0.0f, 0.0f, 0.0f);

        transform.position += Vector3.left * speed;

        

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "fence") {
            bombber.transform.position = respawnpoint.transform.position;
        }

    }
}
