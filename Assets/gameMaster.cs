using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gameMaster : MonoBehaviour
{
    public Button strt;
    public Button rstrt;
    public GameObject player;
    public float d = 0;
    public bool started = false;
    public GameObject Enemy1;

    private float spawnTimer = 1;

    void Start()
    {
        Button b = strt.GetComponent<Button>();
        Button b2 = rstrt.GetComponent<Button>();
        b.onClick.AddListener(startGame);
        b2.onClick.AddListener(restartGame);
        rstrt.gameObject.SetActive(false);
    }
    private void startGame()
    {
        player.GetComponent<playerScript>().startGame();
        strt.gameObject.SetActive(false);
        rstrt.gameObject.SetActive(false);
        started = true;
    }
    private void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(started == true)
        {
            if (d < 25)
            {
                d = d + (float)Time.deltaTime;
            }
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }
            else
            {
                spawnEnemy();
                spawnTimer = 3f - (float)(d* 0.2);
            }
        }
        if (!player)
        {
            rstrt.gameObject.SetActive(true);
        }
    }
    private void spawnEnemy()
    {
        Vector2 pos = new Vector2(Random.Range(-4, 5), 14);
        Instantiate(Enemy1, pos, Quaternion.identity);
    }
    public float getDiff()
    {
        return d;
    }
}
