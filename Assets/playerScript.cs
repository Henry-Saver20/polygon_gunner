using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private Vector3 touchPos;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;
    public bool active;
    private GameObject master;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        active = false;
        master = GameObject.Find("gameHandler");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.touchCount > 0 && active == true)
        {
            Touch t = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(t.position);
            touchPos.z = 0;
            direction = (touchPos - transform.position);
            rb.velocity = new Vector2(direction.x,direction.y)*moveSpeed;
            if(t.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
    public void startGame()
    {
        active = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Yo");
        if (other.gameObject.tag == "Enemy")
        {

            Destroy(this.gameObject);
        }
    }
}
