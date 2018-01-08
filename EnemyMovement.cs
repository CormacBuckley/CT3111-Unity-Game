using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public Vector3 target;
    public float speed = 3f;
    private Animation anim;
    public ParticleSystem explosion;
    private AudioSource source;
    public AudioClip Bang;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    // Use this for initialization
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        target = Camera.main.transform.position - new Vector3(0, 1f, 0) + Vector3.up;
        Vector3 targetDir = target - transform.position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    void onDestroy()
    {
        source.PlayOneShot(Bang, 1F);
    }
}
