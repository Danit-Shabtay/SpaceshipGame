using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float Speed;
    float offscreenY;

    // Start is called before the first frame update
    void Start()
    {
        offscreenY = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > offscreenY)
        {
            Destroy(this.gameObject);
        } else {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meteor"))
        {
            Destroy(this.gameObject);
        }
    }
}
