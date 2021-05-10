using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    private GameObject master;
    private float d = 0.01f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        master = GameObject.Find("gameHandler");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (master.GetComponent<gameMaster>().started == true)
        {
            d = master.GetComponent<gameMaster>().getDiff();
            rb.velocity = new Vector2(0, -1) * (float)(3 + d);
        }   
    }
}
