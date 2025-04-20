using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField]private Camera _camera;
    [SerializeField]private Transform _target;
    [SerializeField] private float pickupRange = 4f;
    [SerializeField] private Transform pickupHoldPosition;
    [SerializeField] private float throwStrength = 250f;
    private GameObject _currentPickupObject;
    private bool _isHolidngObject = false;

    void Update()
    {
        throwOBJ();
        Interaction();
        CheckInteractable();
    }
    
    void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!_isHolidngObject)
            {
                TryPickupObject();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_isHolidngObject)
            {
                DropObject();
            }
        }
    }
    
    void TryPickupObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(_target.transform.position, _target.transform.forward, out hit, pickupRange))
        {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == ("Pickup"))
            {
                _currentPickupObject = hit.collider.gameObject;
                PickupObject();
            }    
        }
    }
    private void throwOBJ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _isHolidngObject)
        {
            _currentPickupObject.GetComponent<Rigidbody>().isKinematic = false;
            _currentPickupObject.transform.SetParent(null);
            Rigidbody PickupObjectRigidBody = _currentPickupObject.GetComponent<Rigidbody>();
            Vector3 throwObject = _target.transform.forward * throwStrength + _target.transform.up * throwStrength;
            PickupObjectRigidBody.AddForce(throwObject , ForceMode.Impulse);
            _isHolidngObject = false;
            _currentPickupObject = null;
        }
    }

    void PickupObject()
    {
        _isHolidngObject = true;
        _currentPickupObject.GetComponent<Rigidbody>().isKinematic = true;
        _currentPickupObject.transform.SetParent(pickupHoldPosition);
        _currentPickupObject.transform.localPosition = Vector3.zero;
    }

    void DropObject()
    {
        _isHolidngObject = false;
        _currentPickupObject.GetComponent<Rigidbody>().isKinematic = false;
        _currentPickupObject.transform.SetParent(null);
        _currentPickupObject = null;
    }
    
    void CheckInteractable()
    {
        RaycastHit hit;
        if (Physics.Raycast(_target.transform.position, _target.transform.forward, out hit, pickupRange))
        {
            if ( hit.collider.gameObject.TryGetComponent(out interactable interact))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interact.Interact();
                }
            }    
        }
    }
    
}
