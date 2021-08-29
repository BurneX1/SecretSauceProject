using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveCameraFocus : InteractableAction
{

    public GameObject camObj;
    public GameObject objetivo;
    public Transform[] curvePoints;
    public float transTime;
    public float dist;
    public Vector3 offset;
    [Range(1, 30)]
    public int segments = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Activation()
    {
        base.Activation();
        camObj.GetComponent<CameraOptions>().curveSg = 0;
        camObj.GetComponent<CameraOptions>().actualFocus = objetivo;
        camObj.GetComponent<CameraOptions>().segmts = curvePoints;
        camObj.GetComponent<CameraOptions>().transitionTime = transTime;
        camObj.GetComponent<CameraOptions>().nearDist = dist;
        camObj.GetComponent<CameraOptions>().focusOffset = offset;

        camObj.GetComponent<CameraOptions>().camType = 3;
    }
    void OnDrawGizmos()
    {

        for (int i = 1; i <= (curvePoints.Length - 1) /2; i++)
        {
            float step = 1f / (float)segments;
            for (int s = 1; s <= segments; s++)
            {
                Vector3 pa = MathTools.BezierLerp(
                    curvePoints[(i - 1) * 2].position,
                    curvePoints[((i - 1) * 2) + 1].position,
                    curvePoints[((i - 1) * 2) + 2].position,
                    (step * (s - 1)));

                Vector3 pb = MathTools.BezierLerp(
                    curvePoints[(i - 1) * 2].position,
                    curvePoints[((i - 1) * 2) + 1].position,
                    curvePoints[((i - 1) * 2) + 2].position,
                    (step * s));

                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(pa, pb);
            }
        }
    }
}
