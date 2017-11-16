using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBoxManager : MonoBehaviour {

    public GameObject _textBox;

    public Text _questionField;
    public Text _answerField;

    public Button _submit;

    public TextAsset _textFile;
    public InputField _input;
    public string[] _textLines;
    public string[] _questions;
    public string[] _answers;

    public int _currentLine;
    public int _endLine;

    public SimpleController player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<SimpleController>();

        if(_textFile != null)
        {
            _textLines = (_textFile.text.Split('\n'));
            parseAnswers();
        }

        if(_endLine == 0)
        {
            _endLine = _questions.Length - 1;
        }
        
	}
	
	// Update is called once per frame
	void Update () {

        _questionField.text = _questions[_currentLine];


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _currentLine++;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            _textBox.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _textBox.SetActive(true);
        }

        if (_currentLine > _endLine)
        {
            _currentLine = 0;
        }
	}

    void parseAnswers()
    {
        int i = 0;
        int k = 0;
        _questions  = new string[_textLines.Length / 2];
        _answers    = new string[_textLines.Length / 2];
        while (i < _textLines.Length - 1)
        {   
            _questions[k] = _textLines[i].Trim();
            
            i++;
            _answers[k] = _textLines[i].Trim();

            i++;
            k++;
        }

    }

    public void checkAnswe()
    {
        
        string UserInput = _input.text.Trim();

        if (UserInput.Equals(_answers[_currentLine]))
        {
            _answerField.text = "You're Right!";
        }
        else
        {
            _answerField.text = "Sorry, that's Wrong. You Entered '" + UserInput + "' but the answer is: '" + _answers[_currentLine] + "'";
        }
    }
}
