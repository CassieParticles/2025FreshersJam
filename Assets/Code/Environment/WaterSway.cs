using Unity.Collections;
using UnityEngine;

public class WaterSway : MonoBehaviour
{
    float xtimer, ytimer, speedMultX, speedMultY;

    Vector2 maxOffset = new Vector2(1.3f, 2.3f);

    [SerializeField][Range(-10f, 10f)] float speedFactorX;
    [SerializeField][Range(-10f, 10f)] float speedFactorY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xtimer = 0;
        ytimer = 0;
    }

    // Update is called once per frame
    void Update() {
        speedMultX = Mathf.Sin(Time.deltaTime * speedFactorX * 5);
        speedMultY = Mathf.Sin(Time.deltaTime * speedFactorY * 5);
        xtimer += Time.deltaTime * speedMultX;
        ytimer += Time.deltaTime * speedMultY;

        transform.position = new Vector2(Mathf.Sin(xtimer), 
                               Mathf.Cos(ytimer));
    }
}
