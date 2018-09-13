using UnityEngine;
using Vuforia;

public class HuntTarget : DefaultTrackableEventHandler {

    public GameManager gameManager;
    public Item item;
    public CollectButton collectButton;

    override protected void OnTrackingFound() {
        base.OnTrackingFound();
        if(!item.isCollected) {
            collectButton.EnableButton(item);
        }
    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();
        collectButton.FadeOut();
    }
}
