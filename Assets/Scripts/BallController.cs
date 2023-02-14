using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    public Vector2 currentVel1;
    public Vector2 ballVel1;
    public Vector2 currentVel2;
    public Vector2 ballVel2;
    //private Text resu;
    //public Text gameover;
    // Start is called before the first frame update

    [PunRPC]
    void ChatMessage1()
    {

        GameManager.flagl = 0;
        //resu.text = "You won";
        GameManager.flagu = 1;
        SceneManager.LoadScene("Final");
    }

    [PunRPC]
    void ChatMessage2()
    {
        GameManager.flagu = 0;
        GameManager.flagl = 1;
        SceneManager.LoadScene("Final");
        //resu.text = "You lost";

    }

    [PunRPC]
    void ChatMessage3()
    {
        GameManager.flagu = 0;
        GameManager.flagl = 1;
        SceneManager.LoadScene("Final");
        //resu.text = "You won";


    }

    [PunRPC]
    void ChatMessage4()
    {

        //resu.text = "You won";
        GameManager.flagu = 1;
        GameManager.flagl = 0;
        SceneManager.LoadScene("Final");
    }

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        if (this.gameObject.tag == "ball")
        {

            ballVel1 = new Vector2(0, 3);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = ballVel1;
        }
        else if (this.gameObject.tag == "ball1")
        {
            ballVel2 = new Vector2(0, -3);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = ballVel2;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "ball")
        {
            currentVel1 = GetComponent<Rigidbody2D>().velocity;
            if (currentVel1.y > 6)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel1.x, 6);
            }
            if (currentVel1.y < -6)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel1.x, -6);
            }
            if (currentVel1.x > 6)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(6, currentVel1.y);
            }
            if (currentVel1.x < -6)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-6, currentVel1.y);
            }
            if ((currentVel1.x == 0) && (currentVel1.y == 0))
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
            }
        }
        else if (this.gameObject.tag == "ball1")
        {
            currentVel2 = GetComponent<Rigidbody2D>().velocity;
            if (currentVel2.y > 6)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel2.x, 6);
            }
            if (currentVel2.y < -6)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel2.x, -6);
            }
            if (currentVel2.x > 6)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(6, currentVel2.y);
            }
            if (currentVel2.x < -6)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-6, currentVel2.y);
            }
            if ((currentVel2.x == 0) && (currentVel2.y == 0))
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3);
            }
        }
        if (this.gameObject.tag == "ball")
        {
            if ((this.gameObject.transform.position.y < -8) || (this.gameObject.transform.position.x < -12.49f) || (this.gameObject.transform.position.x > 13.42f) || ((GameManager.yourresultclient == 1) && (GameManager.yourresultmaster == 0)))
            {
                //PhotonNetwork.LoadLevel("Final");

                //resu = GameObject.Find("Canvas/Result").GetComponent<Text>();
                //resu.text = "You lost";



                SceneManager.LoadScene("Final");
                photonView.RPC("ChatMessage1", RpcTarget.All);
            }
            else if ((GameManager.scorecollected1 == 20) || ((GameManager.yourresultclient == 0) && (GameManager.yourresultmaster == 1)))
            {
                //PhotonNetwork.LoadLevel("Final");


                //resu = GameObject.Find("Canvas/Result").GetComponent<Text>();
                //resu.text = "You won";




                SceneManager.LoadScene("Final");
                photonView.RPC("ChatMessage2", RpcTarget.All);

            }
        }
        if (this.gameObject.tag == "ball1")
        {
            if ((this.gameObject.transform.position.y > 8) || (this.gameObject.transform.position.x < -12.49f) || (this.gameObject.transform.position.x > 13.42f) || ((GameManager.yourresultclient == 0) && (GameManager.yourresultmaster == 1)))
            {
                //PhotonNetwork.LoadLevel("Final");               
                //resu = GameObject.Find("Canvas/Result").GetComponent<Text>();
                //resu.text = "You lost";


                SceneManager.LoadScene("Final");
                photonView.RPC("ChatMessage3", RpcTarget.All);



            }
            else if ((GameManager.scorecollected2 == 20) || ((GameManager.yourresultclient == 1) && (GameManager.yourresultmaster == 0)))
            {
                //PhotonNetwork.LoadLevel("Final");


                //resu = GameObject.Find("Canvas/Result").GetComponent<Text>();
                //resu.text = "You won";
                //if (PhotonNetwork.IsMasterClient)



                SceneManager.LoadScene("Final");
                photonView.RPC("ChatMessage4", RpcTarget.All);




            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (this.gameObject.tag == "ball")
        {
            if (collision.gameObject.name == "leftborder")
            {
                if (currentVel1.x == 0)
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel1.x + 0.3f, currentVel1.y * -1);
            }
            if (collision.gameObject.tag == "paddle")
            {
                if (transform.position.x <= collision.gameObject.transform.GetChild(0).transform.position.x)
                {
                    float fl = collision.gameObject.transform.GetChild(0).transform.position.x - transform.position.x;
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel1.x - fl, currentVel1.y * -1);
                }
                else if (transform.position.x > collision.gameObject.transform.GetChild(0).transform.position.x)
                {
                    float fl = transform.position.x-collision.gameObject.transform.GetChild(0).transform.position.x;
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel1.x + fl, currentVel1.y * -1);
                }
                    
            }
            if ((collision.gameObject.name == "leftborder") || (collision.gameObject.tag == "stone"))
            {
                if ((currentVel1.x >= -1) && (currentVel1.x <= 1))
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel1.x, currentVel1.y * -1);

                else if (currentVel1.y >= 1)
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((currentVel1.x * -1), currentVel1.y);
                else
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((currentVel1.x * -1), currentVel1.y - 0.9f);
            }
            if (collision.gameObject.name == "rightborder")
            {
                if (currentVel1.x == 0)
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel1.x + 0.3f, currentVel1.y * -1);
            }
            if ((collision.gameObject.tag == "rightborder") || (collision.gameObject.tag == "stone"))
            {
                if ((currentVel1.x >= -1) && (currentVel1.x <= 1))
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel1.x * -1, currentVel1.y * -1);
                else if (currentVel1.y >= 1)
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((currentVel1.x * -1), currentVel1.y);
                else
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((currentVel1.x * -1), currentVel1.y - 0.9f);
            }
            if (collision.gameObject.tag == "middleborder")
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel1.x, (currentVel1.y * -1));
            }
        }
        else if (this.gameObject.tag == "ball1")
        {
            if (collision.gameObject.name == "leftborder")
            {
                if (currentVel2.x == 0)
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel2.x - 0.3f, currentVel2.y * -1);
            }
            if (collision.gameObject.tag == "paddle1")
            {
                if (transform.position.x > collision.gameObject.transform.GetChild(0).transform.position.x)
                {
                    float fl = transform.position.x - collision.gameObject.transform.GetChild(0).transform.position.x;
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel2.x + fl, currentVel2.y * -1);
                }
                    
               else if (transform.position.x <= collision.gameObject.transform.GetChild(0).transform.position.x)
                {
                    float fl = collision.gameObject.transform.GetChild(0).transform.position.x - transform.position.x;
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel2.x - fl, currentVel2.y * -1);
                }
            }
            if ((collision.gameObject.tag == "leftborder") || (collision.gameObject.tag == "stone"))
            {
                if ((currentVel2.x >= -1) && (currentVel2.x <= 1))
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel2.x, currentVel2.y * -1);
                else if (currentVel2.y <= -1)
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((currentVel2.x * -1), currentVel2.y);
                else
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((currentVel2.x * -1), currentVel2.y + 0.9f);
            }
            if (collision.gameObject.name == "rightborder")
            {
                if (currentVel2.x == 0)
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel2.x - 0.3f, currentVel2.y * -1);
            }
            if ((collision.gameObject.tag == "rightborder") || (collision.gameObject.tag == "stone"))
            {
                if ((currentVel2.x >= -1) && (currentVel2.x <= 1))
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel2.x, currentVel2.y * -1);
                else if (currentVel2.y <= -1)
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((currentVel2.x * -1), currentVel2.y);
                else
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((currentVel2.x * -1), currentVel2.y + 0.9f);
            }
            if (collision.gameObject.tag == "middleborder")
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVel2.x, (currentVel2.y * -1));
            }

        }
    }
}