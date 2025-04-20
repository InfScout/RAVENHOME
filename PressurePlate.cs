using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] FloorMoving floor;
    void OnTriggerEnter(Collider other)
    {
        floor.MoveFloorForward();
        
    }

    void OnTriggerExit(Collider other)
    {
        StartCoroutine(FloorDelay());
    }
    
    IEnumerator FloorDelay()
    {
        
        yield return new WaitForSeconds(5f);
        floor.MoveFloorBack();
        
    }
    
}
   

