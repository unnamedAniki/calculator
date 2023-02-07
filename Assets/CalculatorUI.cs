using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class CalculatorUI : MonoBehaviour
{
    private Button clearButton;
    private Button calculateButton;
    private Button plusButton;
    private Button minusButton;
    private Button divineButton;
    private Button multipleButton;
    private Label text;
    private List<Button> buttons;

    private string[] button_Titles = new string[] {
        "ZeroButton", "OneButton", "TwoButton", "ThreeButton", "FourButton", "FiveButton",
        "SixButton", "SevenButton", "EightButton", "NineButton"
    };

    double num = 0;
    int plus_count_clicked = 0;
    int minus_count_clicked = 0;
    int multiple_count_clicked = 0;
    int divine_count_clicked = 0;

    void OnEnable()
    {
        buttons = new List<Button>();
        //Получаем ссылку на компонент UIDocument
        var uiDocument = GetComponent<UIDocument>();
        //Находим кнопку таким запросом, в параметр передаем имя кнопки
        for (int i = 0;i < button_Titles.Length; i++)
        {
            Button button = uiDocument.rootVisualElement.Q<Button>(button_Titles[i]);
            button.RegisterCallback<ClickEvent, int>(Input, i);
            buttons.Add(button); 
        }
        clearButton = uiDocument.rootVisualElement.Q<Button>("ClearButton");
        plusButton = uiDocument.rootVisualElement.Q<Button>("PlusButton");
        minusButton = uiDocument.rootVisualElement.Q<Button>("MinusButton");
        multipleButton = uiDocument.rootVisualElement.Q<Button>("MultipleButton");
        divineButton = uiDocument.rootVisualElement.Q<Button>("DivineButton");
        calculateButton = uiDocument.rootVisualElement.Q<Button>("CalculateButton");
        text = uiDocument.rootVisualElement.Q<Label>("NumberOutput");

        //Регистрируем событие нажатия кнопки
        clearButton.RegisterCallback<ClickEvent>(Clear);
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

    void Input(ClickEvent e, int num)
    {
        if(text.text == "0")
        {
            text.text = "";
        }

        text.text += $"{num}";
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
}
