using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBoxManager : MonoBehaviour
{

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

    public bool isActive;
    public bool freezePlayer;

    public SimpleController player;



    // Use this for initialization
    void Start()
    { 

        player = FindObjectOfType<SimpleController>();


        ReloadScript(_textFile);


        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            EnableTextBox();
        }
        if (!isActive)
        {
            return;
        }

        _questionField.text = _questions[_currentLine];


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _currentLine++;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            DisableTextBox();
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
        _questions = new string[_textLines.Length / 2];
        _answers = new string[_textLines.Length / 2];
        while (i < _textLines.Length - 1)
        {
            _questions[k] = _textLines[i].Trim();

            i++;
            _answers[k] = _textLines[i].Trim();

            i++;
            k++;
        }

    }

    public void checkAnswer()
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

    public void EnableTextBox()
    {
        _textBox.SetActive(true);
        isActive = true;

        if (freezePlayer)
        {
            player.frozen = true;
        }
    }
    public void DisableTextBox()
    {
        _textBox.SetActive(false);

        isActive = false;

        player.frozen = false;
    }

    public void ReloadScript(TextAsset textFile)
    {
        if (textFile != null)
        {
            _textLines = new string[1];
            _textLines = textFile.text.Split('\n');
            parseAnswers();
        }

        if (_endLine == 0)
        {
            _endLine = _questions.Length - 1;
        }
    }
}
