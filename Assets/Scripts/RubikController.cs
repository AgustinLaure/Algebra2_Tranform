using CustomMath;
using UnityEngine;

public class RubikController : MonoBehaviour
{
    [SerializeField] private GameObject[] pieces;
    private MyTransform[] piecesTransform = new MyTransform[27];

    [SerializeField] private GameObject piece;

    enum Pieces
    {
        Root,
        LeftAxis,
        RightAxis,
        TopAxis,
        DownAxis,
        ForwardAxis,
        BackAxis
    }

    private void Awake()
    {

    }

    private void Start()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            piecesTransform[i] = pieces[i].GetComponent<RubikPiece>().myTransform;
        }

        MyTransform rootTransform = piecesTransform[0];

        piecesTransform[1].SetParent(rootTransform);
        piecesTransform[2].SetParent(rootTransform);
        piecesTransform[3].SetParent(rootTransform);
        piecesTransform[4].SetParent(rootTransform);
        piecesTransform[5].SetParent(rootTransform);
        piecesTransform[6].SetParent(rootTransform);
    }

    private void Update()
    {
        MyTransform myTrsPiece = piece.GetComponent<RubikPiece>().myTransform;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            myTrsPiece.Rotate(new Vec3(30f,0f,0f), Space.World);
        }
        Debug.Log(myTrsPiece._children.Count);
    }
}
