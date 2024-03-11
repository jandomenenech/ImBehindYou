using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularText : MonoBehaviour
{
    public GameObject navepasillosdef;

    // Start is called before the first frame update
    void Start()
    {
        Transform currentModule = navepasillosdef.transform.GetChild(0); // Get the first child of Navepasillosdef

        for (int i = 1; i < navepasillosdef.transform.childCount; i++)
        { // Iterate over the rest of the children
            Transform nextModule = navepasillosdef.transform.GetChild(i); // Get the next child
            Vector3 nextPosition = currentModule.position + currentModule.forward * currentModule.localScale.z; // Calculate the position of the next module based on the current module's forward direction and scale
            Quaternion nextRotation = currentModule.rotation; // The rotation of the next module is the same as the current module
            GameObject newModule = Instantiate(nextModule.gameObject, nextPosition, nextRotation); // Instantiate the new module at the calculated position and rotation
            currentModule = newModule.transform; // The new module is now the current module for the next iteration
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
