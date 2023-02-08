using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class CalculatorUI : MonoBehaviour
{
    private Button _clearButton;
    private Button _calculateButton;
    private Button _plusButton;
    private Button _minusButton;
    private Button _divineButton;
    private Button _multipleButton;
    private Label _text;
    private List<Button> _resultericButtons;

    private string[] _resultericButtonTitles = new string[] {
        "ZeroButton", "OneButton", "TwoButton", "ThreeButton", "FourButton", "FiveButton",
        "SixButton", "SevenButton", "EightButton", "NineButton"
    };

    private double _result = 0;
    private bool _plusClicked = false;
    private bool _minusClicked = false;
    private bool _multipleClicked = false;
    private bool _divineClicked = false;

    void OnEnable()
    {
        _resultericButtons = new List<Button>();
        //Получаем ссылку на компонент UIDocument
        var uiDocument = GetComponent<UIDocument>();
        //Находим кнопку таким запросом, в параметр передаем имя кнопки
        for (int i = 0;i < _resultericButtonTitles.Length; i++)
        {
            Button numericButton = uiDocument.rootVisualElement.Q<Button>(_resultericButtonTitles[i]);
            numericButton.RegisterCallback<ClickEvent, int>(Input, i);
            _resultericButtons.Add(numericButton); 
        }
        _clearButton = uiDocument.rootVisualElement.Q<Button>("ClearButton");
        _plusButton = uiDocument.rootVisualElement.Q<Button>("PlusButton");
        _minusButton = uiDocument.rootVisualElement.Q<Button>("MinusButton");
        _multipleButton = uiDocument.rootVisualElement.Q<Button>("MultipleButton");
        _divineButton = uiDocument.rootVisualElement.Q<Button>("DivineButton");
        _calculateButton = uiDocument.rootVisualElement.Q<Button>("CalculateButton");
        _text = uiDocument.rootVisualElement.Q<Label>("NumberOutput");

        //Регистрируем событие нажатия кнопки
        _clearButton.RegisterCallback<ClickEvent>(Clear);
        _plusButton.RegisterCallback<ClickEvent>(Plus);
        _minusButton.RegisterCallback<ClickEvent>(Minus);
        _multipleButton.RegisterCallback<ClickEvent>(Multiple);
        _divineButton.RegisterCallback<ClickEvent>(Divine);
        _calculateButton.RegisterCallback<ClickEvent>(Calculate);
    }

    void Clear(ClickEvent e)
    {
        _text.text = "0";
        _result = 0;
    }

    void Input(ClickEvent e, int num)
    {
        if(_text.text == "0")
        {
            _text.text = "";
        }

        _text.text += $"{num}";
    }

    void Plus(ClickEvent e)
    {
        var num = Convert.ToDouble(_text.text);
        if (_minusClicked)
        {
            _result -= num;
            _minusClicked = false;
        }
        else if (_multipleClicked)
        {
            _result *= num;
            _multipleClicked = false;
        }
        else if (_divineClicked)
        {
            _result /= num;
            _divineClicked = false;
        }
        else
        {
            _result += num;
        }
        _plusClicked = true;
        _text.text = "0";
    }

    void Minus(ClickEvent e)
    {
        var num = Convert.ToDouble(_text.text);
        if (_plusClicked)
        {
            _result += num;
            _plusClicked = false;
        }
        else if (_multipleClicked)
        {
            _result *= num;
            _multipleClicked = false;
        }
        else if (_divineClicked)
        {
            _result /= num;
            _divineClicked = false;
        }
        else if (_result == 0)
        {
            _result = num;
        }
        else
        {
            _result -= num;
        }
        _minusClicked = true;
        _text.text = "0";
    }

    void Multiple(ClickEvent e)
    {
        var num = Convert.ToDouble(_text.text);
        if (_plusClicked)
        {
            _result += num;
            _plusClicked = false;
        }
        else if (_minusClicked)
        {
            _result -= num;
            _minusClicked = false;
        }
        else if (_divineClicked)
        {
            _result /= num;
            _divineClicked = false;
        }
        else if (_result == 0)
        {
            _result = num;
        }
        else
        {
            _result *= num;
        }
        _multipleClicked = true;
        _text.text = "0";
    }

    void Divine(ClickEvent e)
    {
        var num = Convert.ToDouble(_text.text);
        if (_plusClicked)
        {
            _result += num;
            _plusClicked = false;
        }
        else if (_minusClicked)
        {
            _result -= num;
            _minusClicked = false;
        }
        else if (_multipleClicked)
        {
            _result *= num;
            _multipleClicked = false;
        }
        else if (_result == 0)
        {
            _result = num;
        }
        else
        {
            _result /= num;
        }
        _divineClicked = true;
        _multipleClicked = false;
        _minusClicked = false;
        _plusClicked = false;
        _text.text = "0";
    }

    void CheckButtonClicked()
    {
        if (_plusClicked)
        {
            _result += Convert.ToDouble(_text.text);
            _plusClicked = false;
        }
        else if (_minusClicked)
        {
            _result -= Convert.ToDouble(_text.text);
            _minusClicked = false;
        }
        else if (_multipleClicked)
        {
            _result *= Convert.ToDouble(_text.text);
            _multipleClicked = false;
        }
        else if (_divineClicked)
        {
            _result /= Convert.ToDouble(_text.text);
            _divineClicked = false;
        }
    }
    void Calculate(ClickEvent e)
    {
        CheckButtonClicked();
        _text.text = $"{_result}";
        _result = 0;
    }
}
