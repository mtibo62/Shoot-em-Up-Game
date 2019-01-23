using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notificationBehavior : MonoBehaviour
{

    public SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        StartCoroutine(blink());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator blink()
    {
        yield return new WaitForSeconds(.25f);

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0f);

        yield return new WaitForSeconds(.25f);

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f);

        yield return new WaitForSeconds(.25f);

        Destroy(gameObject);
    }


}
