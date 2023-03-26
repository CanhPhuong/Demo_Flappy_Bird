using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject obj;
    private float speed;
    private float moveRange;
    private Vector2 oldPosition;
    void Start()
    {
        speed = 5;
        moveRange = 10;
        obj = gameObject;
        oldPosition = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (Vector2.Distance(oldPosition, obj.transform.position) > moveRange)
        {
            obj.transform.position = oldPosition;
        }
    }
}