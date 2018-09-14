using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CollectButton : MonoBehaviour {
    private IEnumerator _fadeOut;
    private Button _button;
    private TextMeshProUGUI _textMeshProUGUI;
    private Image[] _images;
    private Item _currentItem;

    void Start () {
        _button = transform.GetComponentInChildren<Button>();
        _textMeshProUGUI = transform.GetComponentInChildren<TextMeshProUGUI>();
        _images = transform.GetComponentsInChildren<Image>();
        _button.interactable = false;

        HideButton();
    }    

    public void EnableButton(Item item) {
            CancelFadeOut();
            _button.interactable = true;
            _textMeshProUGUI.text = $"Collect {item.itemName}!";
            _currentItem = item;
            ShowButton();
    }

    public void CollectItem() {
        if (!_currentItem.isCollected) {
            _currentItem.isCollected = true;
            _textMeshProUGUI.text = $"{_currentItem.itemName} Collected!";
            FadeOut();
        }
    }
	
	public void FadeOut() {
        if(_currentItem != null && gameObject.activeInHierarchy) {
            _fadeOut = Fade();
            StartCoroutine(_fadeOut);
        }
    }

    private void CancelFadeOut() {
        if (_fadeOut != null) {
            StopCoroutine(_fadeOut);
        }
    }

    private void ShowButton() {
        CancelFadeOut();
        UpdateAlphas(1f);
    }

    private void HideButton() {
        UpdateAlphas(0f);
    }

    private void UpdateAlphas(float alpha) {
        if (_images != null && _images.Length > 0) {
            for (int i = 0; i < _images.Length; i++) {
                Color c = _images[i].color;
                c.a = alpha;
                _images[i].color = c;
            }
        }
        if (_textMeshProUGUI != null) {
            Color c = _textMeshProUGUI.color;
            c.a = alpha;
            _textMeshProUGUI.color = c;
        }
    }

    IEnumerator Fade() {
        yield return new WaitForSeconds(.5f);
        for(float alpha = 1f; alpha >= 0; alpha -= 0.01f) {
            UpdateAlphas(alpha);
            yield return null;
        }
        HideButton();
        _currentItem = null;
        _button.interactable = false;
    }
}
