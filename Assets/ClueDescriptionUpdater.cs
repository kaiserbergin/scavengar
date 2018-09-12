using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClueDescriptionUpdater : MonoBehaviour {
    private TextMeshProUGUI _textMeshProUGUI;
    private string _text;
    private ClueItem _clueItem;

    private void Start() {
        _textMeshProUGUI = transform.GetComponent<TextMeshProUGUI>();
        _clueItem = transform.parent.GetComponent<ClueItem>();
        _text = _clueItem.item.clue;
        _textMeshProUGUI.text = _text;
    }
}
