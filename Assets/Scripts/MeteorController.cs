using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public GameObject MeteorExplostionPrefab;

    public float meteorSpeed;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        maxY = Camera.main.ViewportToWorldPoint(new Vector3 (0, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < maxY )
        {
            Destroy(this.gameObject);
        }

        transform.Translate(Vector3.down * meteorSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Missile") || other.CompareTag("Player"))
        {
            Instantiate(MeteorExplostionPrefab, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
