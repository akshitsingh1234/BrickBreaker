using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag== "paddle")
        {
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
        }
        else if(this.gameObject.tag == "paddle1")
        {
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
        }
    }
}
