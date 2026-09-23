using UnityEngine;
using System.Collections.Generic;

public class SpawnGraynd : MonoBehaviour
{

    public GameObject[] grounds;
    private List<GameObject> groyndsList = new List<GameObject>();
    private float spawnPos = 0;
    public float groundLength = 100;

    public Transform player;
    private int startGround = 6;

    void Start()
    {
        
        for (int i = 0; i < startGround; i++)
        {

            Spawn(Random.Range(0, grounds.Length));

        }

    }

    void Update()
    {

        if (player.position.z - 100 > spawnPos - (startGround * groundLength))
        {
            Spawn(Random.Range(0, grounds.Length));
            DestroyGrounds();
            Debug.Log("спавн");
        }

    }

    void Spawn(int index)
    {

        GameObject nextGround = Instantiate(grounds[index], transform.forward * spawnPos, transform.rotation);
        groyndsList.Add(nextGround);
        spawnPos += groundLength;

    }

    
    void DestroyGrounds()
    {

        Destroy(groyndsList[0]);
        groyndsList.RemoveAt(0);

    }

}
