using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoints : MonoBehaviour
{
        public GameObject parentObject;
    private void Start()
    {
        parentObject = this.gameObject;
    }
    private void Update()
    {
        while (parentObject.transform.childCount > 0)
        {
            foreach (Transform child in parentObject.transform)
            {
                child.gameObject.transform.parent = null;
            }
        }
    }
}
