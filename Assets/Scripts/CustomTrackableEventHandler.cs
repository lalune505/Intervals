using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTrackableEventHandler : DefaultTrackableEventHandler
{
    #region PUBLIC_MEMBERS
    public GameObject panelScan;
    public List<GameObject> stickerPrefabs;
    #endregion //PUBLIC_MEMBERS

    #region PRIVATE_MEMBERS
    private GameObject currentPrefab;
    #endregion //PRIVATE_MEMBERS


    #region PROTECTED_METHODS
    protected override void OnTrackingFound()
    {
        if (panelScan.activeSelf)
        { 
            panelScan.SetActive(false); 
        }
            
        if (currentPrefab == null)
        {
            int prefabIndex = UnityEngine.Random.Range(0, 17);
            //currentPrefab = stickerPrefabs[prefabIndex];
            currentPrefab = Instantiate(stickerPrefabs[prefabIndex], this.gameObject.transform, false);
        }

        base.OnTrackingFound();
    }

    #endregion //PROTECTED_METHODS
}
