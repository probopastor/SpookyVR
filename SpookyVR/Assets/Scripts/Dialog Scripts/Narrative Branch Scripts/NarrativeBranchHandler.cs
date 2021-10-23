using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeBranchHandler : MonoBehaviour
{
    [SerializeField, Tooltip(" ")] private int[] narrativeBranchThresholds;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateBranchThreshold(int branchNumber)
    {
        // Check to make sure the branch number is not outside the parameters of the narrativeBranchThreshold array
        if ((branchNumber - 1 < narrativeBranchThresholds.Length) && (branchNumber - 1 > 0))
        {
            // If the branch number threshold is over 0, decrease it
            if (narrativeBranchThresholds[branchNumber - 1] > 0)
            {
                narrativeBranchThresholds[branchNumber - 1] -= 1;
            }

            // If the branch number threshold is at 0, switch branches
            if (narrativeBranchThresholds[branchNumber - 1] == 0)
            {

            }
        }
    }
}
