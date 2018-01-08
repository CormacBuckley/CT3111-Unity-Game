using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollision : MonoBehaviour {

    public ParticleSystem flash;
    // Use this for initialization
    void OnCollisionEnter(Collision col)
    {

        
            var em = flash.emission;
            em.enabled = true;
            flash.Play();
        if (col.gameObject.tag != "Nodestroy")
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        
    }
    }
}
