using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectButton : MonoBehaviour {
    private IEnumerator _fadeOut;
    private List<Renderer> _renderers;
    private Button _button;
    private TextMeshProUGUI _textMeshProUGUI;

    void Start () {
        _button = transform.GetComponentInChildren<Button>();
        _textMeshProUGUI = transform.GetComponentInChildren<TextMeshProUGUI>();

        AddRenderers();
        

        _button.interactable = false;

        for (int i = 0; i < _renderers.Count; i++) {
            Color c = _renderers[i].material.color;
            c.a = 0f;
            _renderers[i].material.color = c;
        }
    }

    public void EnableButton(Item item) {
        if(!item.isCollected) {
            CancelFadeOut();
            _button.interactable = true;
            _textMeshProUGUI.text = $"Collect {item.itemName}!";
            ShowButton();
        }        
    }
	
	public void FadeOut() {
        _fadeOut = Fade();
        StartCoroutine(_fadeOut);
    }

    private void AddRenderers() {
        Image[] images = transform.GetComponentsInChildren<Image>();
        for (int i = 0; i < images.Length; i++) {
            Renderer r = images[i].GetComponent<Renderer>();
            if(r != null) _renderers.Add(r);
        }
    }

    private void CancelFadeOut() {
        if (_fadeOut != null) {
            StopCoroutine(_fadeOut);
        }
    }

    private void ShowButton() {
        for(int i = 0; i < _renderers.Count; i++) {
            Color c = _renderers[i].material.color;
            c.a = 1f;
            _renderers[i].material.color = c;
        }        
    }

    IEnumerator Fade() {
        for (float f = 1f; f >= 0; f -= 0.1f) {
            for (int i = 0; i < _renderers.Count; i++) {
                Color c = _renderers[i].material.color;
                c.a = f;
                _renderers[i].material.color = c;
            }
            yield return null;
        }
        _button.interactable = false;
    }
}
