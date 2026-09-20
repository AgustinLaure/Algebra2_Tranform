using CustomMath;
using UnityEngine;

public class RubikPiece : MonoBehaviour
{
    [SerializeField] private MyTransform parent;

    public MyTransform myTransform;

    private Mesh mesh;
    private Material mat;

    private void Awake()
    {
        myTransform = new MyTransform(transform);
    }
    private void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        mat = GetComponent<MeshRenderer>().material;

        GetComponent<MeshRenderer>().enabled = false;
    }
    private void Update()
    {
        Graphics.DrawMesh(mesh, myTransform.localToWorldMatrix, mat, gameObject.layer);

        Debug.Log(myTransform.localScale.x + " - " + myTransform.localScale.y + " - " + myTransform.localScale.z);

        if (transform.hasChanged)
        {
            myTransform.position = transform.position;
            myTransform.rotation = transform.rotation;
            myTransform.localScale = transform.localScale;
        
            transform.hasChanged = false;
            myTransform.hasChanged = false;
        }
    }
}
