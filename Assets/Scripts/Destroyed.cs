using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
        if (other.gameObject.tag == "ball")
        {
            GameManager.scorecollected1++;
            Debug.Log(GameManager.scorecollected1);
        }
        else if (other.gameObject.tag == "ball1")
        {
            GameManager.scorecollected2++;
            Debug.Log(GameManager.scorecollected2);
        }
    }
}
