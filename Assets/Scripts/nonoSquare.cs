
using UnityEngine;using UnityEngine.Events;

public class nonoSquare : MonoBehaviour
{ 
    public UnityEvent trigger;
    [SerializeField]private GameObject player;
   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trigger.Invoke();
        }
    }
}
