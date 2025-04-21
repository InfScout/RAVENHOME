using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class FloorMoving : MonoBehaviour
{
    [FormerlySerializedAs("doorMesh")] [SerializeField] private Transform floorMesh;
    [SerializeField] private Transform targetPosition;
    [FormerlySerializedAs("_doorMoveSpeed")] [SerializeField] private float _floorMoveSpeed = .01f;

    private Vector3 originPosition;
    private bool _isOpened;
    private float _floorMoveAlpha;
    private WaitForSeconds _floorTickTime = new WaitForSeconds(.01f);
    private WaitForSeconds _floorWaitTime = new WaitForSeconds(1f);
    
    void Start()
    {
        originPosition = floorMesh.localPosition;
    }

    IEnumerator FloorMoveTick(float alphaChange)
    {
        yield return _floorTickTime;
        _floorMoveAlpha = Mathf.Clamp(_floorMoveAlpha += alphaChange, 0, 1f);
        floorMesh.localPosition = Vector3.Lerp(originPosition, targetPosition.localPosition, _floorMoveAlpha);

        if (_floorMoveAlpha == 1f)
        {
            _isOpened = true;
        }
        else if (_floorMoveAlpha == 0f)
        {
            _isOpened = false;
        }
        else
        {
            StartCoroutine(FloorMoveTick(alphaChange));
        }
    }

    public void MoveFloorForward()
    {
        if (!_isOpened)
        {
            StartCoroutine(FloorMoveTick(_floorMoveSpeed));
        }
    }
    
    public void MoveFloorBack()
    {
        if (_isOpened)
        {
            StartCoroutine(FloorMoveTick(-_floorMoveSpeed));
        }
    }
    
}