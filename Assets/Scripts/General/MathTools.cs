using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTools
{
    static public Vector3 BezierLerp(Vector3 PA, Vector3 PB, Vector3 PC, float t)
    {

        Vector3 P1 = Vector3.Lerp(PA, PB, t);
        Vector3 P2 = Vector3.Lerp(PB, PC, t);

        Vector3 P = Vector3.Lerp(P1, P2, t);

        return P;
    }   
}
