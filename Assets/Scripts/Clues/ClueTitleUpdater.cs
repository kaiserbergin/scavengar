using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClueTitleUpdater : MonoBehaviour {
    private TextMeshProUGUI _textMeshProUGUI;
    private string _title;
    private ClueItem _clueItem;

    private void Start() {
        _textMeshProUGUI = transform.GetComponent<TextMeshProUGUI>();
        _title = "???";
        _clueItem = transform.parent.GetComponent<ClueItem>();
        _textMeshProUGUI.text = _title;
    }

    private void Update() {
        if (_clueItem.item.isCollected && _title == "???") {
            _title = _clueItem.item.itemName;
            _textMeshProUGUI.text = _title;
        }
    }
}
