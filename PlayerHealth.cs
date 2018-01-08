using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour {


    public float max_health = 100f;
    public float cur_health = 0;
    public GameObject HealthBar;
    public GameObject player;
    public GameObject[] target;
    // Use this for initialization
    void Awake() {
        cur_health = max_health;
            
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < target.Length; i++) { 
        float dist = Vector3.Distance(player.transform.position, target[i].transform.position);
        if (dist < 2f)
        {
            decHealth();
        }
    }
    }


    void decHealth()
    {
        cur_health -= Random.Range(.1f, .3f);
        float calcHealth = cur_health / max_health;
        setBar(calcHealth);
        if(cur_health <= 0)
        {
            CancelInvoke();
            SceneManager.LoadScene("Defeat", LoadSceneMode.Single);
        }
    }

    void setBar(float health)
    {
        HealthBar.transform.localScale = new Vector3(Mathf.Clamp(health, 0f, 1f), HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
    }
}
