using UnityEngine;
using System.Collections;

public class GunFire : MonoBehaviour
{
    public int ammo = 10;
    public Transform startPoint;
    public AudioClip shot;
    public AudioClip heavyShot;
    public GameObject projectile;
    public GameObject heavyProjectile;
    private float speed = 3000f;
    private float heavySpeed = 700f;
    private Animation anim;
    public ParticleSystem flash;
    public GameObject can;

    private AudioSource source;
    // Use this for initialization

    void Start()
    {
        Cursor.visible = false;
    }
    void Awake()
    {
        source = GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
           
            anim.Play();
            source.PlayOneShot(shot, 1F);
            GameObject fire = Instantiate(projectile, startPoint.position, transform.rotation) as GameObject;
            //Rigidbody f = fire.GetComponent<Rigidbody>();

           // f.AddRelativeForce(fire.transform.right * speed);

            var em = flash.emission;
            em.enabled = true;
            flash.Play();
            ammo--;
            Destroy(fire, 1);

        }

        if (Input.GetMouseButtonDown(1) && ammo > 0)
        {
          
            anim.Play();

            source.PlayOneShot(heavyShot, 1F);

            GameObject fire = Instantiate(heavyProjectile, startPoint.position, transform.rotation) as GameObject;
            Rigidbody f = fire.GetComponent<Rigidbody>();

            f.AddRelativeForce(fire.transform.right * heavySpeed);

            var em = flash.emission;
            em.enabled = true;
            flash.Play();

            ammo--;

            Destroy(fire, 5f);
        }

        if (Input.GetKeyDown("r"))
        {

            ammo = 10;
            anim.Play("Reload");

        }
    }
}