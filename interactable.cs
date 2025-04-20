using UnityEngine;
using UnityEngine.Events;


public class interactable : MonoBehaviour
{
    public UnityEvent OnInteract;
    
    public void Interact()
    {
        OnInteract.Invoke();
    }
    
}
