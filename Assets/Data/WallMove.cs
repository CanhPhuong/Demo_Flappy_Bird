using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject obj;
    private float speed;
    private float oldPosition;
    private float minY = -1.5f;
    private float maxY = -5.5f;
    void Start()
    {
        obj = gameObject;
        oldPosition = 25;
        speed = 7;

    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(Vector2.left * speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ResetWall"))
        {
            
            obj.transform.position = new Vector2(oldPosition, Random.Range(minY, maxY));
        }

    }
}