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
            Vector3 newPos;

            if(side == Side.Left)
            {
                newPos = Camera.main.ViewportToWorldPoint(new Vector2(0.05f, 0.5f));
            }
            else
            {
                newPos = Camera.main.ViewportToWorldPoint(new Vector2(0.95f, 0.5f));
            }
            newPos.z = 0;
            transform.position = newPos;
        }
    }

    public void Awake()
    {
        side = Side.Left;
        Vector3 newPos = Camera.main.ViewportToWorldPoint(new Vector2(0.05f, 0.5f));
        newPos.z = 0;
        transform.position = newPos;
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
