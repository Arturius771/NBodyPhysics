using UnityEngine;

public class BezierController : MonoBehaviour
{
    // CREDIT: https://www.youtube.com/watch?v=wtoPrJadjz4

    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject controlPoint1;
    [SerializeField] private GameObject controlPoint2;
    [SerializeField] private GameObject target;

    [SerializeField] private GameObject controlledObject;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float time;

    public float sensitivity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        controlledObject.transform.position = startPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        bool scrollingUp = Input.mouseScrollDelta.y == 1;
        bool scrollingDown = Input.mouseScrollDelta.y == -1;
        bool canScrollUp = time < 0.9f;
        bool canScrollDown = time > 0.0f;

        if (scrollingUp && canScrollUp) {
            time += 0.05f * sensitivity;
        }
       
        if (scrollingDown && canScrollDown)
        {
            time -= 0.05f * sensitivity;
        }

        controlledObject.transform.position = GetPointOnBezierCurve(startPoint.transform.position, controlPoint1.transform.position, controlPoint2.transform.position, target.transform.position, time);
        controlledObject.transform.LookAt(target.transform.position);
    }


    Vector3 Lerp(Vector3 a, Vector3 b, float t) { 
        return (1f - t) * a + t * b;
    }

    Vector3 GetPointOnBezierCurve(Vector3 startPoint, Vector3 controlPoint1, Vector3 controlPoint2, Vector3 target, float t) {
        Vector3 a = Lerp(startPoint, controlPoint1, t);
        Vector3 b = Lerp(controlPoint1, controlPoint2, t);
        Vector3 c = Lerp(controlPoint2, target, t);
        Vector3 d = Lerp(a, b, t);
        Vector3 e = Lerp(b, c, t);
        Vector3 pointOnCurve = Lerp(d, e, t);

        return pointOnCurve;
    }

    //    // Optimised version of GetPointOnBezierCurve()

    //    //Vector3 GetPointOnBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
    //    //    float u = 1f - t;
    //    //    float t2 = t * t;
    //    //    float u2 = u * u;
    //    //    float u3 = u2 * u;
    //    //    float t3 = t2 * t;

    //    //    Vector3 result =
    //    //        (u3) * p0 +
    //    //        (3f * u2 * t) * p1 +
    //    //        (3f * u * t2) * p2 +
    //    //        (t3) * p3;

    //    //    return result;
    //    //}
}