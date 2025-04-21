using UnityEngine;

public class Camera : MonoBehaviour
{
  public Transform CameraPos;

  private void Update()
  {
    transform.position = CameraPos.position;
  }
}
