using UnityEngine;

public class PlaceableObjectsBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Collider collider;
    [SerializeField]
    public bool isTrigger;

    void Awake()
    {
        collider = GetComponent<BoxCollider>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMaterial(Material material)
    {

    }
}
