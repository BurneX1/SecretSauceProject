using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riel : MonoBehaviour
{
    private int totalSegments
    {
        get
        {
            return (points.Count - 1) / 2;
        }
    }
    public GameObject grab;
    public GameObject camPoint;

    public List<Transform> points;
    public Vector3 position;
    public int currentSegment;
    public float u;

    public Vector3 actPos;
    public Vector3 plusPos;
    public Vector3 restPos;

    [Range(0f, 1f)]
    public float t;

    [Range(1, 30)]
    public int segments = 5;


    void Start()
    {
        t = 0f;
    }

    void Update()
    {
        /*t += Time.deltaTime * 0.5f;

        if (t >= 1f)
            t = 0;*/
        if (t >= 1f)
        {
            t = 1f;
        }
        else if (t <= 0f)
        {
            t = 0f;
        }

        /*if (currentSegment == 0)
        {
            actPos = MathTools.BezierLerp(
               points[(1 - 1) * 2].position,
               points[((1 - 1) * 2) + 1].position,
               points[((1 - 1) * 2) + 2].position,
               (t * totalSegments) - (1 - 1));

            plusPos = MathTools.BezierLerp(
               points[(1 - 1) * 2].position,
               points[((1 - 1) * 2) + 1].position,
               points[((1 - 1) * 2) + 2].position,
               ((t + (Time.deltaTime * 0.5f)) * totalSegments) - (1 - 1));

            restPos = MathTools.BezierLerp(
               points[(1 - 1) * 2].position,
               points[((1 - 1) * 2) + 1].position,
               points[((1 - 1) * 2) + 2].position,
               ((t - (Time.deltaTime * 0.5f)) * totalSegments) - (1 - 1));
        }
        else*/
        //{
        actPos = MathTools.BezierLerp(
           points[(currentSegment - 1) * 2].position,
           points[((currentSegment - 1) * 2) + 1].position,
           points[((currentSegment - 1) * 2) + 2].position,
           (t * totalSegments) - (currentSegment - 1));

        plusPos = MathTools.BezierLerp(
           points[(currentSegment - 1) * 2].position,
           points[((currentSegment - 1) * 2) + 1].position,
           points[((currentSegment - 1) * 2) + 2].position,
           ((t + (Time.deltaTime * 0.5f)) * totalSegments) - (currentSegment - 1));

        restPos = MathTools.BezierLerp(
           points[(currentSegment - 1) * 2].position,
           points[((currentSegment - 1) * 2) + 1].position,
           points[((currentSegment - 1) * 2) + 2].position,
           ((t - (Time.deltaTime * 0.5f)) * totalSegments) - (currentSegment - 1));
        //}


        if (Vector3.Distance(actPos, grab.transform.position) > Vector3.Distance(plusPos, grab.transform.position) && t < 1f)
        {
            t += Time.deltaTime * 0.5f;
        }
        else if (Vector3.Distance(actPos, grab.transform.position) > Vector3.Distance(restPos, grab.transform.position) && t > 0.001f)
        {
            t -= Time.deltaTime * 0.5f;
        }

        if (t >= 1f)
        {
            t = 1f;
        }
        else if (t <= 0f)
        {
            t = 0f;
        }
        if (camPoint)
        {
            camPoint.transform.position = position;
        }

        Positioning();
    }

    void Positioning()
    {
        currentSegment = Mathf.Max(Mathf.CeilToInt(totalSegments * t), 1);
        u = (t * totalSegments) - (currentSegment - 1);

        position = MathTools.BezierLerp(
                points[(currentSegment - 1) * 2].position,
                points[((currentSegment - 1) * 2) + 1].position,
                points[((currentSegment - 1) * 2) + 2].position,
                u);
    }

    void OnDrawGizmos()
    {

        currentSegment = Mathf.Max(Mathf.CeilToInt(totalSegments * t), 1);
        u = (t * totalSegments) - (currentSegment - 1);

            position = MathTools.BezierLerp(
                            points[(currentSegment - 1) * 2].position,
                            points[((currentSegment - 1) * 2) + 1].position,
                            points[((currentSegment - 1) * 2) + 2].position,
                            u);


        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(position, Vector3.one * 0.3f);



        for (int i = 1; i <= totalSegments; i++)
        {
            float step = 1f / (float)segments;
            for (int s = 1; s <= segments; s++)
            {
                Vector3 pa = MathTools.BezierLerp(
                    points[(i - 1) * 2].position,
                    points[((i - 1) * 2) + 1].position,
                    points[((i - 1) * 2) + 2].position,
                    (step * (s - 1)));

                Vector3 pb = MathTools.BezierLerp(
                    points[(i - 1) * 2].position,
                    points[((i - 1) * 2) + 1].position,
                    points[((i - 1) * 2) + 2].position,
                    (step * s));

                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(pa, pb);
            }
        }

    }
}
