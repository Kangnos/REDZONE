using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public ParticleSystem ps;

    public float time;

    private void FixedUpdate()
    {
        if(ps)
        {
            if(!ps.IsAlive())
            {
                Destroy(gameObject, time);
            }
        }
    }

}
