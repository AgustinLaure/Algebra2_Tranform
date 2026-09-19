using CustomMath;
using UnityEngine;

public class RubikPiece : MonoBehaviour
{
    [SerializeField] private MyTransform parent;

    public MyTransform myTransform;

    private void Awake()
    {
        myTransform = new MyTransform(transform);
    }
    private void Start()
    {

    }
    private void Update()
    {
        Debug.Log(myTransform.position);

        if (myTransform.hasChanged)
        {
            transform.position = myTransform.position;
            transform.rotation = myTransform.rotation;
            transform.localScale = myTransform.localScale;

            myTransform.hasChanged = false;
            transform.hasChanged = false;
        }

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
