/* 
* Glory to the High Council
* William Nomikos
* IDisplayResources.cs
* Interface to be implemented by Display Resource scripts. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDisplayResources
{
    /// <summary>
    /// Sets the resource manager the display resources script will use
    /// </summary>
    void SetResourceManager();

    /// <summary>
    /// Will update all display resources of a given location.
    /// </summary>
    void UpdateDisplayedResources();
}
