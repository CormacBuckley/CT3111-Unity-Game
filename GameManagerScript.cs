using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerScript : MonoBehaviour {

   // public PlayerHealth playerHealth;       // Reference to the player's heatlh.
    public GameObject drone;
    public GameObject bug; // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public GameObject[] enemies;

    // Use this for initialization



    void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int enemies_Alive = enemies.Length;

        if(enemies_Alive == 0)
        {
            SceneManager.LoadScene("Victory", LoadSceneMode.Single);
        }
           
       
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        if (spawnPoints[spawnPointIndex].position != null)
        {
            
            Instantiate(drone, spawnPoints[spawnPointIndex].position + new Vector3(0, 2, 0), spawnPoints[spawnPointIndex].rotation);
            Instantiate(bug, spawnPoints[spawnPointIndex].position + new Vector3(0, 0, 0), spawnPoints[spawnPointIndex].rotation);
        }
    }


}
