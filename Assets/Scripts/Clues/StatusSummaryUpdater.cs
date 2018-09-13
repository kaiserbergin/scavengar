using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class StatusSummaryUpdater : MonoBehaviour {
    public GameManager gameManager;
    private TextMeshProUGUI _textMesh;

    private void Start() {
        if (_textMesh == null) {
            _textMesh = transform.GetComponent<TextMeshProUGUI>();
        }
    }

    private void Update() {
        var collectedItems = gameManager.Items.FindAll(x => x.isCollected == true).Count;
        _textMesh.text = $"{collectedItems} / {gameManager.Items.Count} Items Found";
    }
}
