using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PrincessMovement : MonoBehaviour
{
    public enum Side
    {
        Left, Right 
    };

    [SerializeField] private float minChangeTime = 10;
    [SerializeField] private float maxChangeTime = 15;

    public Side side { get; private set; }

    private Coroutine coroutine;

    private IEnumerator ChangeSides()
    {
        while(true)
        {
            //Wait random period of time
            float randomTime = Random.Range(minChangeTime, maxChangeTime);
            yield return new WaitForSeconds(randomTime);

            side = (side == Side.Left ? Side.Right : Side.Left);

            if(side == Side.Left)
            {
                transform.position = Camera.main.ViewportToWorldPoint(new Vector2(0.05f, 0.5f));
            }
            else
            {
                transform.position = Camera.main.ViewportToWorldPoint(new Vector2(0.95f, 0.5f));
            }
        }
    }

    public void Awake()
    {
        side = Side.Left;
        transform.position = Camera.main.ViewportToWorldPoint(new Vector2(0.05f, 0.5f));
    }

    private void OnEnable()
    {
        coroutine = StartCoroutine(ChangeSides());
    }

    private void OnDisable()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
}
