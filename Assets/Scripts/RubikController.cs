using CustomMath;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using Unity.VisualScripting;

public class RubikController : MonoBehaviour
{
    [SerializeField] private GameObject[] pieces;
    private MyTransform[] piecesTransform = new MyTransform[27];

    [SerializeField] private GameObject root;
    private MyTransform rootTransform;

    [SerializeField] private float rotationTime;

    private MyTransform currentAxis;

    private Coroutine rotatingCoroutine = null;

    private float localDistBetweenPieces = 0.1f;

    private const float epsilon = 0.01f;

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

        rootTransform = piecesTransform[0];

        for (int i = 1; i < pieces.Length; i++)
        {
            piecesTransform[i].SetParent(rootTransform);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentAxis = piecesTransform[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentAxis = piecesTransform[2];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentAxis = piecesTransform[3];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentAxis = piecesTransform[4];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentAxis = piecesTransform[5];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            currentAxis = piecesTransform[6];
        }

        if (currentAxis != null)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (rotatingCoroutine == null)
                {
                    rotatingCoroutine = StartCoroutine(RotateAxisCoroutine(-90f));
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (rotatingCoroutine == null)
                {
                    rotatingCoroutine = StartCoroutine(RotateAxisCoroutine(90f));
                }
            }
        }
    }

    private IEnumerator RotateAxisCoroutine(float angle)
    {
        List<MyTransform> toRotate = new List<MyTransform>();
        for (int i = 7; i < piecesTransform.Length; i++)
        {
            Vec3 distance = piecesTransform[i].localPosition - currentAxis.localPosition;

            distance = new Vec3(Mathf.Abs(distance.x), Mathf.Abs(distance.y), Mathf.Abs(distance.z));

            if (distance.x <= localDistBetweenPieces + epsilon && distance.y <= localDistBetweenPieces + epsilon && distance.z <= localDistBetweenPieces + epsilon && (distance.x < epsilon || distance.y < epsilon || distance.z < epsilon))
            {
                toRotate.Add(piecesTransform[i]);
            }
        }

        for (int i = 0; i < toRotate.Count; i++)
        {
            toRotate[i].SetParent(currentAxis);
        }

        Vec3 rootDirection = Vec3.Zero;

        float t = 0;
        float rotation = 0f;
        while (t < 1f)
        {
            rootDirection = (currentAxis.position - rootTransform.position).normalized;

            t += Time.deltaTime / rotationTime;

            rotation += Time.deltaTime * (angle / rotationTime);

            currentAxis.Rotate(rootDirection, Time.deltaTime * (angle / rotationTime), Space.World);

            yield return null;
        }

        rootDirection = (currentAxis.position - rootTransform.position).normalized;
        float snapDifference = angle - rotation;
        
        currentAxis.Rotate(rootDirection, snapDifference, Space.World);

        for (int i = 0; i < toRotate.Count; i++)
        {
            toRotate[i].SetParent(rootTransform);
        }

        rotatingCoroutine = null;
    }

    private void OnDrawGizmos()
    {
        if (currentAxis != null)
        {
            Vec3 rootPos = root.GetComponent<RubikPiece>().myTransform.position;
            Vec3 currentAxisPos = currentAxis.position;

            Vec3 rootToAxis = (currentAxisPos - rootPos).normalized;

            Gizmos.DrawSphere(new Vec3(currentAxisPos + rootToAxis * 0.15f), 0.05f);
        }
    }
}
