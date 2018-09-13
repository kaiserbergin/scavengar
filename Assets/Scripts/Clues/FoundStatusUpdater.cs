using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoundStatusUpdater : MonoBehaviour {
    private TextMeshProUGUI _textMeshProUGUI;
    private string _text;
    private ClueItem _clueItem;

    private void Start() {
        _textMeshProUGUI = transform.GetComponent<TextMeshProUGUI>();
        _text = "Not Found";
        _clueItem = transform.parent.GetComponent<ClueItem>();
        _textMeshProUGUI.text = _text;
    }

    private void Update() {
        if (_clueItem.item.isCollected && _text == "Not Found") {
            _text = _clueItem.item.itemName;
            _textMeshProUGUI.text = "Found!";
            _textMeshProUGUI.fontStyle = FontStyles.Normal;
        }
    }
}
