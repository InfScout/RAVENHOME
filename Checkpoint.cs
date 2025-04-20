using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]private Transform checkpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.GetInstance().spawnPoint.transform.position = checkpoint.transform.position;
        }
    }
}
