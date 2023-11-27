using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentCleaner : MonoBehaviour
{
    [SerializeField] private Transform contentRoot;

    public void ClearPanel()
    {
        int childCount = contentRoot.childCount;

        if (childCount == 0)
        {
            return;
        }

        for (int i = (childCount - 1); i >= 0; i--)
        {
            Destroy(contentRoot.GetChild(i).gameObject);
        }
    }
}
