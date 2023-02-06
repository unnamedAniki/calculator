using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class CalculatorUI : MonoBehaviour
{
    Button clearButton;
    Button oneButton;
    Button twoButton;
    Button threeButton;
    Button fourButton;
    Button fiveButton;
    Button sixButton;
    Button sevenButton;
    Button eightButton;
    Button nineButton;
    Button zeroButton;
    Button calculateButton;
    Button plusButton;
    Button minusButton;
    Button divineButton;
    Button multipleButton;

    Label text;

    double num = 0;
    int plus_count_clicked = 0;
    int minus_count_clicked = 0;
    int multiple_count_clicked = 0;
    int divine_count_clicked = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        //Получаем ссылку на компонент UIDocument
        var uiDocument = GetComponent<UIDocument>();
        //Находим кнопку таким запросом, в параметр передаем имя кнопки
        clearButton = uiDocument.rootVisualElement.Q<Button>("ClearButton");
        oneButton = uiDocument.rootVisualElement.Q<Button>("OneButton");
        twoButton = uiDocument.rootVisualElement.Q<Button>("TwoButton");
        threeButton = uiDocument.rootVisualElement.Q<Button>("ThreeButton");
        fourButton = uiDocument.rootVisualElement.Q<Button>("FourButton");
        fiveButton = uiDocument.rootVisualElement.Q<Button>("FiveButton");
        sixButton = uiDocument.rootVisualElement.Q<Button>("SixButton");
        sevenButton = uiDocument.rootVisualElement.Q<Button>("SevenButton");
        eightButton = uiDocument.rootVisualElement.Q<Button>("EightButton");
        nineButton = uiDocument.rootVisualElement.Q<Button>("NineButton");
        zeroButton = uiDocument.rootVisualElement.Q<Button>("ZeroButton");
        plusButton = uiDocument.rootVisualElement.Q<Button>("PlusButton");
        minusButton = uiDocument.rootVisualElement.Q<Button>("MinusButton");
        multipleButton = uiDocument.rootVisualElement.Q<Button>("MultipleButton");
        divineButton = uiDocument.rootVisualElement.Q<Button>("DivineButton");
        calculateButton = uiDocument.rootVisualElement.Q<Button>("CalculateButton");
        text = uiDocument.rootVisualElement.Q<Label>("NumberOutput");
        //Регистрируем событие нажатия кнопки
        clearButton.RegisterCallback<ClickEvent>(Clear);
        oneButton.RegisterCallback<ClickEvent>(InputOne);
        twoButton.RegisterCallback<ClickEvent>(InputTwo);
        threeButton.RegisterCallback<ClickEvent>(InputThree);
        fourButton.RegisterCallback<ClickEvent>(InputFour);
        fiveButton.RegisterCallback<ClickEvent>(InputFive);
        sixButton.RegisterCallback<ClickEvent>(InputSix);
        sevenButton.RegisterCallback<ClickEvent>(InputSeven);
        eightButton.RegisterCallback<ClickEvent>(InputEight);
        nineButton.RegisterCallback<ClickEvent>(InputNine);
        zeroButton.RegisterCallback<ClickEvent>(InputZero);

        plusButton.RegisterCallback<ClickEvent>(Plus);
        minusButton.RegisterCallback<ClickEvent>(Minus);
        multipleButton.RegisterCallback<ClickEvent>(Multiple);
        divineButton.RegisterCallback<ClickEvent>(Divine);
        calculateButton.RegisterCallback<ClickEvent>(Calculate);
    }

    void Clear(ClickEvent e)
    {
        text.text = "0";
        num = 0;
    }

    void InputOne(ClickEvent e)
    {
        if(text.text == "0")
        {
            text.text = "";
        }
        text.text += "1";
    }

    void InputTwo(ClickEvent e)
    {
        if (text.text == "0")
        {
            text.text = "";
        }
        text.text += "2";
    }

    void InputThree(ClickEvent e)
    {
        if (text.text == "0")
        {
            text.text = "";
        }
        text.text += "3";
    }

    void InputFour(ClickEvent e)
    {
        if (text.text == "0")
        {
            text.text = "";
        }
        text.text += "4";
    }

    void InputFive(ClickEvent e)
    {
        if (text.text == "0")
        {
            text.text = "";
        }
        text.text += "5";
    }

    void InputSix(ClickEvent e)
    {
        if (text.text == "0")
        {
            text.text = "";
        }
        text.text += "6";
    }

    void InputSeven(ClickEvent e)
    {
        if (text.text == "0")
        {
            text.text = "";
        }
        text.text += "7";
    }

    void InputEight(ClickEvent e)
    {
        if (text.text == "0")
        {
            text.text = "";
        }
        text.text += "8";
    }

    void InputNine(ClickEvent e)
    {
        if (text.text == "0")
        {
            text.text = "";
        }
        text.text += "9";
    }

    void InputZero(ClickEvent e)
    {
        if (text.text == "0")
        {
            text.text = "";
        }
        text.text += "0";
    }

    void Plus(ClickEvent e)
    {
        num += Convert.ToDouble(text.text);
        plus_count_clicked = 1;
        minus_count_clicked = 0;
        multiple_count_clicked = 0;
        divine_count_clicked = 0;
        text.text = "0";
    }

    void Minus(ClickEvent e)
    {
        num -= Convert.ToDouble(text.text);
        minus_count_clicked = 1;
        plus_count_clicked = 0;
        multiple_count_clicked = 0;
        divine_count_clicked = 0;
        text.text = "0";
    }

    void Multiple(ClickEvent e)
    {
        if(num == 0)
        {
            num = Convert.ToDouble(text.text);
        }
        else
        {
            num *= Convert.ToDouble(text.text);
        }
        multiple_count_clicked = 1;
        minus_count_clicked = 0;
        plus_count_clicked = 0;
        divine_count_clicked = 0;
        text.text = "0";
    }

    void Divine(ClickEvent e)
    {
        if (num == 0)
        {
            num = Convert.ToDouble(text.text);
        }
        else
        {
            num /= Convert.ToDouble(text.text);
        }
        divine_count_clicked = 1;
        multiple_count_clicked = 0;
        minus_count_clicked = 0;
        plus_count_clicked = 0;
        text.text = "0";
    }

    void Calculate(ClickEvent e)
    {
        if(plus_count_clicked != 0)
        {
            num += Convert.ToDouble(text.text);
            plus_count_clicked = 0;
        }
        if(minus_count_clicked != 0)
        {
            num -= Convert.ToDouble(text.text);
            minus_count_clicked = 0;
        }
        if(multiple_count_clicked != 0)
        {
            num *= Convert.ToDouble(text.text);
            multiple_count_clicked = 0;
        }
        if (divine_count_clicked != 0)
        {
            num /= Convert.ToDouble(text.text);
            divine_count_clicked = 0;
        }

        text.text = $"{num}";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
