using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject MeteorPrefab;

    public float minSpeed;
    public float maxSpeed;
    public float SpawnRate;
    public float SpawnStart;

    Vector2 min;
    Vector2 max;

    // Start is called before the first frame update
    void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));

        InvokeRepeating("SpawnMeteor", SpawnStart, SpawnRate);
    }

    void SpawnMeteor()
    {
        float meteorExtentsX = MeteorPrefab.GetComponent<Renderer>().bounds.extents.x;
        float meteorExtentsY = MeteorPrefab.GetComponent<Renderer>().bounds.extents.y;

        float randomX = Random.Range(min.x + meteorExtentsX, max.x - meteorExtentsX);

        Vector2 randomPosition = new Vector2(randomX, max.y + meteorExtentsY);

        GameObject Meteor = Instantiate(MeteorPrefab, randomPosition, Quaternion.identity);
        Meteor.GetComponent<MeteorController>().meteorSpeed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
