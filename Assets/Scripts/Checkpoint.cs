using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]private Transform checkpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AUDIO.GetInstance().PlaySound(AUDIO.GetInstance().checkpoint);
            GameManager.GetInstance().spawnPoint.transform.position = checkpoint.transform.position;
        }
    }
}
