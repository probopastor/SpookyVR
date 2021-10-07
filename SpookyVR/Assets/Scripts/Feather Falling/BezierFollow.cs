using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    [SerializeField, Tooltip("This is a container of routes the intended object will follow")]
    private Transform[] routes = new Transform[0];

    // The starting control point to start at.
    private int routeToGo = 0;

    // This varaible is the same t value as the For loop in the Route.cs script.
    private float tParam = 0f;

    private Vector2 objectPosition = new Vector2(0f, 0f);

    [SerializeField, Tooltip("Falling speed of the object")]
    private float objectSpeed = 0.5f;

    [Tooltip("Maintains whether bezier curve movement is in progress. True if it is, false otherwise. ")] private bool bezierMovementInProgress = false;

    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        //objectSpeed = 0.5f;
        bezierMovementInProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Notes/Ideas:

        // start corotuine in Scheduleaction.cs

        // Make route prefab (good idea).

        // Make object take in Route (Not now). 

        // Automatic Curve Positioning.

        //if(coroutineAllowed)
        //{
        //    StartCoroutine(GoByRoute(GetRouteToGo()));
        //}

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

    public IEnumerator GoByRoute(int routeNumber)
    {
        bezierMovementInProgress = true;

        Vector2 p0 = routes[routeNumber].GetChild(0).position;
        Vector2 p1 = routes[routeNumber].GetChild(1).position;
        Vector2 p2 = routes[routeNumber].GetChild(2).position;
        Vector2 p3 = routes[routeNumber].GetChild(3).position;

        while ((tParam < 1) && bezierMovementInProgress)
        {
            tParam += Time.deltaTime * GetObjectSpeed();

            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

            transform.position = objectPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;

        routeToGo += 1;
        SetRouteToGo(routeToGo);

        if (routeToGo > routes.Length - 1)
        {
            SetRouteToGo(0);
        }

        bezierMovementInProgress = false;
    }

    /// <summary>
    /// This method returns a bool based on if 
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
            // Do Something that disable UI elements
            result = true;
            return result;
        }
        else
        {
            // Do something that re-enable UI elements
            result = false;
            return result;
        }
    }

    public bool ActiveStatus () => gameObject.activeInHierarchy;


    #region Getters and Setters

    public int GetRouteToGo()
    {
        return routeToGo;
    }

    public void SetRouteToGo(int value)
    {
        routeToGo = value;
    }

    public float GetObjectSpeed()
    {
        return objectSpeed;
    }

    public void SetObjectSpeed(float value)
    {
        objectSpeed = value;
    }

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
