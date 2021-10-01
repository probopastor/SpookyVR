/* 
* Glory to the High Council
* William Nomikos
* DisplayResources.cs
* The DisplayResources superclass. All levels should have their own DisplayResources script that inherits from this,
* in order to set which resources should be displayed there. This script will be called by GameManager to maintain
* resources.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DisplayResources : MonoBehaviour
{
    /// <summary>
    /// Sets the resource manager the display resources script will use
    /// </summary>
    public abstract void SetResourceManager();

    /// <summary>
    /// Will update all display resources of a given location.
    /// </summary>
    public abstract void UpdateDisplayedResources();
}
