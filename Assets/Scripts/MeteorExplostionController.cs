using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorExplostionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyAnimation()
    {
        float AnimationTime = GetComponent<Animator> ().GetCurrentAnimatorClipInfo(0).Length;

        yield return new WaitForSeconds(AnimationTime);

        Destroy(this.gameObject);
    }
}
