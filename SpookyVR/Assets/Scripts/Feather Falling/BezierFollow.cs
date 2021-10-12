/* 
* Glory to the High Council
* CJ Green, William Nomikos
* BezierFollow.cs
* [what this does]
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    [SerializeField, Tooltip("This is a container of routes the intended object will follow")] private Transform[] routes = new Transform[0];

    [Tooltip("The starting control point to start at. ")] private int routeToGo = 0;

    [Tooltip("This varaible is the same t value as the For loop in the Route.cs script. ")] private float tParam = 0f;

    private Vector2 objectPosition = new Vector2(0f, 0f);

    [SerializeField, Tooltip("Falling speed of the object. ")] private float objectSpeed = 0.15f;

    [Tooltip("Maintains whether bezier curve movement is in progress. True if it is, false otherwise. ")] private bool bezierMovementInProgress = false;

    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        bezierMovementInProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Notes/Ideas:
        // Make route prefab.
        // Make object take in Route. 

        // Automatic Curve Positioning.


        if (gameObject.activeInHierarchy == true && CheckIfObjectIsOffScreen(gameObject))
        {
            GameObject.Destroy(gameObject);
            Debug.Log("Is off screen.");
        }
        else if (gameObject.activeInHierarchy == true && !CheckIfObjectIsOffScreen(gameObject))
        {
            Debug.Log("Is not off screen.");
        }
    }

    private void OnEnable()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Feather Falling")
        {
            //StartCoroutine(GoByRoute());
            Debug.Log("This bezier thing is now visible.");

            //PositionObjectAndRoute(gameObject.transform, routes);

        }
    }

    public IEnumerator GoByRoute()
    {

        PositionObjectAndRoute(gameObject.transform, routes);

        bezierMovementInProgress = true;

        Vector2 p0 = routes[routeToGo].GetChild(0).position;
        Vector2 p1 = routes[routeToGo].GetChild(1).position;
        Vector2 p2 = routes[routeToGo].GetChild(2).position;
        Vector2 p3 = routes[routeToGo].GetChild(3).position;

        while ((tParam < 1) && bezierMovementInProgress)
        {
            tParam += Time.deltaTime * objectSpeed;

            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

            transform.position = objectPosition;
            yield return null;
        }

        tParam = 0f;

        routeToGo += 1;

        if (routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }

        bezierMovementInProgress = false;
    }

    /// <summary>
    /// This ensures that the object always is positioned on the Route correctly.
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="routes"></param>
    public void PositionObjectAndRoute(Transform gameObject, Transform[] routes)
    {
        Transform gameObjectPosition = gameObject;
        Transform route = routes[routeToGo];

        if (gameObjectPosition.transform.position != route.transform.position)
        {

            //gameObject.transform.position = firstControlPoint.transform.position;
            Debug.Log("Big dummy");
            //gameObject.position = firstControlPoint;

            route.transform.position = gameObject.transform.position;

            //Debug.Log("The #1 control point position is: " + route);
            //Debug.Log("The gameObject position is: " + gameObjectPosition);

        }
        else
        {
            Debug.Log("They are the same!");
        }
    }

    /// <summary>
    /// This method returns a bool based on if the object is on screen anymore or not.
    /// </summary>
    /// <param name="objectToCheck"></param>
    /// <returns></returns>
    public bool CheckIfObjectIsOffScreen(GameObject objectToCheck)
    {
        bool result = false;
        Vector3[] v = new Vector3[4];
        objectToCheck.GetComponent<RectTransform>().GetWorldCorners(v);

        float maxY = Mathf.Max(v[0].y, v[1].y, v[2].y, v[3].y);
        float minY = Mathf.Min(v[0].y, v[1].y, v[2].y, v[3].y);

        //This is for if we wanted Horizontal checking.
        //float maxX = Mathf.Max (v [0].x, v [1].x, v [2].x, v [3].x);
        //float minX = Mathf.Min (v [0].x, v [1].x, v [2].x, v [3].x);

        if (maxY < 0 || minY > Screen.height)
        {
            result = true;
            return result;
        }
        else
        {
            result = false;
            return result;
        }
    }

    #region Getters and Setters

    /// <summary>
    /// Gets whether Bezier Curve movement is in progress.
    /// </summary>
    /// <returns>Returns true if Bezier Curve movement is in progress, false otherwise.</returns>
    public bool GetBezierMovementInProgress()
    {
        return bezierMovementInProgress;
    }

    /// <summary>
    /// Sets whether Bezier Curve movement is currently in progress.
    /// </summary>
    /// <param name="value">Set True if Bezier Curve movement is in progress, false otherwise.</param>
    public void SetBezierMovementInProgress(bool value)
    {
        bezierMovementInProgress = value;
    }

    #endregion
}
