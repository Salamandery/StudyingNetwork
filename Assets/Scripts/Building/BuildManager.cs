using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    private static BuildManager instance;
    public GameObject[] objects;
    public float maxDistance;
    public float gridSize;
    public float rotateAmmout;
    public bool canPlace;
    public Material[] objectMaterials = new Material[2];
    private Color objectColor;
    private Material objectMaterial;
    private bool gridOn;
    private GameObject currentObject;
    private Vector3 position;
    private RaycastHit hit;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Toggle gridToggle;

    public static BuildManager MyInstance {
        get {
            if (instance == null)
            {
                instance = FindObjectOfType<BuildManager>();
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gridOn = true;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentObject != null)
        {
            ObjectPosition();
            BuildingActions();
            UpdateMaterials();
        }
    }

    private void ObjectPosition()
    {
        if (gridOn)
        {
            currentObject.transform.position = new Vector3(
                    RoundToNearestGrid(position.x),
                    RoundToNearestGrid(position.y),
                    RoundToNearestGrid(position.z)
            );
        }
        else
        {
            currentObject.transform.position = position;
        }
    }

    private void BuildingActions()
    {
        if (Input.GetMouseButtonDown(0) && canPlace)
        {
            PlaceObject();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RotateObject();
        }
    }

    public void PlaceObject()
    {
        ToggleTransparenceMode(1);
        objectColor.a = 255f;
        SetObjectMaterial(objectMaterial);

        if (!currentObject.GetComponent<PlaceableObjectsBehaviour>().isTrigger)
        {
            currentObject.GetComponent<PlaceableObjectsBehaviour>().isTrigger = false;
        }

        currentObject = null;
    }

    public void RotateObject()
    {
        currentObject.transform.Rotate(Vector3.up, rotateAmmout);
    }

    private void FixedUpdate()
    {
        if (Camera.main != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
            {
                position = hit.point;
            }
        }
    }

    public void ToggleGrid()
    {
        if (gridToggle.isOn)
        {
            gridOn = true;
        }
        else
        {
            gridOn = false;
        }
    }

    private float RoundToNearestGrid(float position)
    {
        float xDiff = position % gridSize;
        position -= xDiff;

        if (xDiff > (gridSize / 2))
        {
            position += gridSize;
        }

        return position;
    }

    public void SelectObject(int index)
    {
        currentObject = Instantiate(objects[index], position, transform.rotation);

        objectMaterial = currentObject.GetComponent<Renderer>().material;
        objectColor = objectMaterial.color;

        objectColor.a = 190f;
        ToggleTransparenceMode(0);
    }

    public void UpdateMaterials()
    {
        if (currentObject != null)
        {
            if (canPlace)
            {
                SetObjectMaterial(objectMaterials[0]);
            }
            else
            {
                SetObjectMaterial(objectMaterials[1]);
            }
        }
    }

    private void SetObjectMaterial(Material material)
    {
        currentObject.GetComponent<Renderer>().material = material;
    }

    private void ToggleTransparenceMode(float mode)
    {
        switch (mode)
        {
            case 0f:
                objectMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                objectMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                objectMaterial.SetInt("_ZWrite", 0);
                objectMaterial.DisableKeyword("_ALPHATEST_ON");
                objectMaterial.DisableKeyword("_ALPHABLEND_ON");
                objectMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                objectMaterial.renderQueue = 3000;
                break;
            case 1f:
                objectMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                objectMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                objectMaterial.SetInt("_ZWrite", 1);
                objectMaterial.DisableKeyword("_ALPHATEST_ON");
                objectMaterial.DisableKeyword("_ALPHABLEND_ON");
                objectMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                objectMaterial.renderQueue = -1;
                break;
            default:
                break;
        }
    }
}
