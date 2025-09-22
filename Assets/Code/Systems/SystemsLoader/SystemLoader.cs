using System.Runtime.CompilerServices;
using UnityEngine;

public class SystemLoader : MonoBehaviour
{
    [SerializeField] private GameObject systemCollection;
    private void Awake()
    {
        //Create System collection if one doesn't exist, or destroy self if one does
        if(!FindAnyObjectByType<SystemCollection>())
        {
            Instantiate(systemCollection);
        }
        Destroy(gameObject);
    }
}
