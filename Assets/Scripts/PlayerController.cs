using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Lives;

    public float numBlinks;
    public float blinkSedonds;

    public GameObject missilePrefab;
    public Transform missileSpawn;

    float maxWidth;
    float maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0);
        Vector3 targetWidth = Camera.main.ScreenToViewportPoint(upperCorner);

        float playerWidth = GetComponent<Renderer>().bounds.extents.x;
        float playerHeight = GetComponent<Renderer>().bounds.extents.y;

        maxWidth = targetWidth.x + playerWidth;
        maxHeight = targetWidth.y + playerHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        UpdatePosition();
    }

    void Fire()
    {
        Instantiate(missilePrefab, missileSpawn.position, Quaternion.identity);
    }

    void UpdatePosition()
    {
        Vector3 rawPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, rawPosition.y, 0.0f);

        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        float targetHeight = Mathf.Clamp(targetPosition.y, -maxHeight, maxHeight);

        targetPosition = new Vector3(targetWidth, targetHeight, targetPosition.z);

        transform.position = targetPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meteor"))
        {
            DestroyPlayer();
        }
    }

    void DestroyPlayer()
    {
        Lives--;
        StartCoroutine(RespawnPlayer(numBlinks, blinkSedonds));

    }

    IEnumerator RespawnPlayer(float numBlinks, float seconds)
    {
        Renderer renderer = GetComponent<Renderer>();
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();

        boxCollider2D.enabled = false;

        for(int i=0; i<numBlinks*2; i++)
        {
            renderer.enabled = !renderer.enabled;

            yield return new WaitForSeconds(seconds);
        }

        boxCollider2D.enabled = true;
    }
}
