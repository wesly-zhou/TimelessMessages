using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    // Start is called before the first frame update
    // The distance the platform can move
    public float amplitude; 
    public float speed; 
    public bool vertical;
    public bool horizontal;

    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (vertical) {
            VerticalMove();
        } else if (horizontal) {
            HorizontalMove();
        }
    }

    private void VerticalMove() {
        float newY = startPosition.y + amplitude * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    private void HorizontalMove() {
        float newX = startPosition.x + amplitude * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(newX, startPosition.y, startPosition.z);
    }
}
