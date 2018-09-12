using UnityEngine;
using Vuforia;

public class HuntTarget : DefaultTrackableEventHandler {

    public GameManager gameManager;
    public Item item;

    override protected void OnTrackingFound() {
        base.OnTrackingFound();
        if(!item.isCollected) {
            item.isCollected = true;
            Debug.Log(item.itemName);
        }
    }
}
