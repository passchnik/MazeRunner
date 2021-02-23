using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float playerSpeed = 5f;

    bool moveAllowed = false;

    public Rigidbody2D rb;
    public Transform player;

    private Vector2 _movement;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform circle;
    public Transform outerCircle;


    void Start () {

       //rb = gameObject.GetComponent<Rigidbody2D>(); 
        
        // intitialization of start pozition
	}


    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            //circle.transform.position = pointA * -1;
            //outerCircle.transform.position = pointA * -1;
            //circle.gameObject.SetActive(true);
            //outerCircle.gameObject.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }



        //_movement.x = Input.GetAxisRaw("Horizontal");
        //_movement.y = Input.GetAxisRaw("Vertical");

    }

    public void FixedUpdate()
    {

        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * 1);

            //circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;
        }
        else
        {
            //circle.gameObject.SetActive(false);
            //outerCircle.gameObject.SetActive(false);


        }

        //rb.MovePosition(rb.position + _movement * playerSpeed * Time.fixedDeltaTime);
    }


    void moveCharacter(Vector2 direction)
    {
        //rb.MovePosition(rb.position + direction * playerSpeed * Time.fixedDeltaTime);

       player.Translate(direction * playerSpeed * Time.deltaTime);
    }

}
