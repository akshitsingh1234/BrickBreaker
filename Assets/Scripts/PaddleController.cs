using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public float speed = 0.06f;
    private Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if (UNITY_EDITOR || UNITY_STANDALONE_WIN)
            if (Input.GetKey(left))
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
            }
            if (Input.GetKey(right))
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
            }
            if (!(Input.GetKey(left)) && !(Input.GetKey(right)))
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
#elif UNITY_ANDROID
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
                transform.position = new Vector2(transform.position.x + touch.deltaPosition.x * speed, transform.position.y);
#endif



    }
}
