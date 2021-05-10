using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour
{
    public SpriteRenderer map;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        float sRatio = (float)Screen.width / (float)Screen.height;
        float tRatio = map.bounds.size.x / map.bounds.size.y;
        //float oSize = map.bounds.size.x * Screen.height / Screen.width * 0.5f;
        //Camera.main.orthographicSize = oSize;
        if(sRatio >= tRatio)
        {
            Camera.main.orthographicSize = map.bounds.size.y / 2;
        }
        else
        {
            Camera.main.orthographicSize = (map.bounds.size.y / 2 ) * (float)(tRatio / sRatio);
        }
    }

    // Update is called once per frame
}
