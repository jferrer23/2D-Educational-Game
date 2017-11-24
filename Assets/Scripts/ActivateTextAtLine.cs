using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset _text;

    public int _startLine;
    public int _endLine;

    public TextBoxManager _textBoxManager;

    public bool _requireButtonPress;
    private bool _waitForPress;

	// Use this for initialization
	void Start () {
        _textBoxManager = FindObjectOfType<TextBoxManager>();

	}
	
	// Update is called once per frame
	void Update () {
		if(_waitForPress && Input.GetKeyDown(KeyCode.O))
        {
            SetScriptToController();
        }
	}


    void SetScriptToController()
    {
        _textBoxManager._currentLine = _startLine;
        _textBoxManager._endLine = _endLine;
        _textBoxManager.ReloadScript(_text);

        
    }

    void OnTriggerEnter2d(Collider2D other)
    {
        if(other.name == "Player")
        {
            if (_requireButtonPress)
            {
                _waitForPress = true;
                return;
            }
            _textBoxManager.EnableTextBox();
            SetScriptToController();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            _waitForPress = false;
        }
    }


}
