using UnityEngine;
using UnityEngine.Events;

public class Pressure : MonoBehaviour
{
  public UnityEvent OnPressure;
  public UnityEvent offPressure;
  void OnTriggerEnter(Collider other)
  {
    AUDIO.GetInstance().PlaySound(AUDIO.GetInstance().button);
    OnPressure.Invoke();
  }

  void OnTriggerExit(Collider other)
  {
    offPressure.Invoke();
  }
}
