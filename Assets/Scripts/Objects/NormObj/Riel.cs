using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class Riel : MonoBehaviour
{
    private int totalSegments
    {
        get
        {
            return (points.Length - 1) / 2;
        }
    }
    //public GameObject grab;
    //public GameObject camPoint;

    public GrabPreset[] targetArrays;

    public Transform[] points;
    public bool regeneratePoints;
    public Vector3 position;
    //public int currentSegment;
    public float u;

    public Vector3 actPos;
    public Vector3 plusPos;
    public Vector3 restPos;

    [Range(0f, 1f)]
    public float t;

    [Range(1, 30)]
    public int segments = 5;

    private void Awake()
    {
        if(regeneratePoints == true)
        {
            PointNormalization();
        }

    }
    void Start()
    {
        //t = 0f;
    }

    void Update()
    {
        for(int i = 0; i < targetArrays.Length; i++)
        {
            Segmentation(targetArrays[i]);
        }

        //Positioning();
    }

    void Segmentation(GrabPreset preset)
    {
        Vector3 position;
        int currentSegment;
        float u;

        Vector3 actPos;
        Vector3 plusPos;
        Vector3 restPos;





        if (preset.t >= 1f)
        {
            preset.t = 1f;
        }
        else if (preset.t <= 0f)
        {
            preset.t = 0f;
        }

        /*------------------*/
        currentSegment = Mathf.Max(Mathf.CeilToInt(totalSegments * preset.t), 1);
        u = (preset.t * totalSegments) - (currentSegment - 1);

        position = MathTools.BezierLerp(
                points[(currentSegment - 1) * 2].position,
                points[((currentSegment - 1) * 2) + 1].position,
                points[((currentSegment - 1) * 2) + 2].position,
                u);
        /*------------------*/



        actPos = MathTools.BezierLerp(
           points[(currentSegment - 1) * 2].position,
           points[((currentSegment - 1) * 2) + 1].position,
           points[((currentSegment - 1) * 2) + 2].position,
           (preset.t * totalSegments) - (currentSegment - 1));

        plusPos = MathTools.BezierLerp(
           points[(currentSegment - 1) * 2].position,
           points[((currentSegment - 1) * 2) + 1].position,
           points[((currentSegment - 1) * 2) + 2].position,
           ((preset.t + (Time.deltaTime * 0.5f)) * totalSegments) - (currentSegment - 1));

        restPos = MathTools.BezierLerp(
           points[(currentSegment - 1) * 2].position,
           points[((currentSegment - 1) * 2) + 1].position,
           points[((currentSegment - 1) * 2) + 2].position,
           ((preset.t - (Time.deltaTime * 0.5f)) * totalSegments) - (currentSegment - 1));
        //}


        if (Vector3.Distance(actPos, preset.target.transform.position) > Vector3.Distance(plusPos, preset.target.transform.position) && preset.t < 1f)
        {
            preset.t +=  Time.deltaTime * 0.5f;
        }
        else if (Vector3.Distance(actPos, preset.target.transform.position) > Vector3.Distance(restPos, preset.target.transform.position) && preset.t > 0.001f)
        {
            preset.t -=  Time.deltaTime * 0.5f;
        }

        if (preset.t >= 1f)
        {
            preset.t = 1f;
        }
        else if (preset.t <= 0f)
        {
            preset.t = 0f;
        }
        if (preset.point)
        {
            preset.point.transform.position = position;
        }


        
    }

    void PointNormalization()
    {
        if(points.Length > 1)
        {
            Transform[] newArray = new Transform[1];
            newArray[0] = points[0];
            Debug.Log(newArray[0]);
            for (int i = 0; i < points.Length;i++)
            {

                if (i != points.Length - 1)
                {
                    int axisDiff = 0;
                    Vector3 diff = new Vector3(
                        (points[i].position.x - points[i+1].position.x), 
                        (points[i].position.y - points[i + 1].position.y), 
                        (points[i].position.z - points[i + 1].position.z)
                        );
                    if (diff.x != 0) axisDiff++;
                    if (diff.y != 0) axisDiff++;
                    if (diff.z != 0) axisDiff++;
                    if (axisDiff == 1)
                    {
                        int pntInter = Mathf.CeilToInt((diff.x + diff.y + diff.z) / 1f);
                        for(int e = 1; e < pntInter;e++)
                        {
                            int dir = 1;
                            if(diff.x + diff.y + diff.z > 0)
                            {
                                dir = -1;
                            }
                            GameObject tmp = Instantiate(new GameObject("extraPoint"));
                            tmp.transform.parent = gameObject.transform;
                            tmp.transform.position = points[i].position + ((diff / pntInter) * (e)) * dir ;
                            newArray = newArray.Concat(new Transform[] { tmp.transform }).ToArray();
                            Debug.Log(newArray.Length);
                        }

                    }
                    newArray = newArray.Concat(new Transform[] { points[i+1].transform }).ToArray();
                }
                //if (newArray.Length % 2 == 0)
                //{
                //    GameObject tmp = Instantiate(new GameObject("extraPoint"));
                //    tmp.transform.parent = gameObject.transform;
                //    tmp.transform.position = points[points.Length - 1].position;
                //    newArray = newArray.Concat(new Transform[] { tmp.transform }).ToArray();

                //}
            }
            Debug.Log(newArray[0]);
            points = newArray;
        }
    }

    void OnDrawGizmos()
    {


        Gizmos.color = Color.cyan;
        for (int i = 0; i < targetArrays.Length; i++)
        {
            Gizmos.DrawCube(targetArrays[i].point.transform.position, Vector3.one * 0.3f);
        }




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

[System.Serializable]
public class GrabPreset
{
    public GameObject point;
    public GameObject target;
    //[HideInInspector]
    public float t;


}
