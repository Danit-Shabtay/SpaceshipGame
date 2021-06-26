using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

        maxWidth = targetWidth.x - playerWidth;
        maxHeight = targetWidth.y - playerHeight;
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
}
