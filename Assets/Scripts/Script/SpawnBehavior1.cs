using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehavior1 : MonoBehaviour
{
    // Reference to the player's heatlh.
    public GameObject _enemy;                // The enemy prefab to be spawned.
    public float _spawnTime = 0.5f;            // How long between each spawn.
    public float _RespawnTime = 0f;
    public Transform[] thespawnPoints; // An array of the spawn points this enemy can spawn from.
    public float _numEnemies = 20f;
    public float count = 0f;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        
        
        InvokeRepeating("Spawn", _spawnTime, _RespawnTime);
    }

    void Spawn()
    {
        count += 1f;
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, thespawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        if(count < _numEnemies)
            Instantiate(_enemy, thespawnPoints[spawnPointIndex].position, thespawnPoints[spawnPointIndex].rotation);
    }
}
