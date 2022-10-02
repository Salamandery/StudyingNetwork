using UnityEngine;

public class CheckPlacementBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform);
        if (other.gameObject.CompareTag("PlaceableObjects"))
        {
            BuildManager.MyInstance.canPlace = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log(other.transform);
        if (other.gameObject.CompareTag("PlaceableObjects"))
        {
            BuildManager.MyInstance.canPlace = true;
        }
    }
}
