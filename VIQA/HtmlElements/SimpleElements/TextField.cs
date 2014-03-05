﻿using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using VIQA.HtmlElements.Interfaces;

namespace VIQA.HtmlElements
{
    public class TextField : TextElement, ITextArea
    {
        public const string LocatorTmpl = "input[type=text][{0}={1}]";
        public static string CommonLocatorById(string id) { return string.Format(LocatorTmpl, "id", id); }
        public static string CommonLocatorByNamed(string id) { return string.Format(LocatorTmpl, "name", id); }
        public static string CommonLocatorByClassName(string id) { return string.Format(LocatorTmpl, "class", id); }

        protected override string _typeName { get { return "TextField"; } }

        public override Func<string> DefaultGetLabelFunc { get { return () => GetWebElement().GetAttribute("value"); } }

        public TextField(string name = "") : base(name) { }
        public TextField(string name, string cssSelector) : base(name, cssSelector) { }
        public TextField(string name, By byLocator, List<By> byContext = null) : base(name, byLocator, byContext) { }
        public TextField(By byLocator, List<By> byContext = null) : base(byLocator, byContext) { }
        public TextField(string name, IWebElement webElement) : base(name, webElement) { }
        public TextField(IWebElement webElement) : base(webElement) { }
        
        public void Input(string text)
        {
            DoVIAction("Input text " + text + " in text field", () => GetWebElement().SendKeys(text));
        }

        public void NewInput(string text)
        {
            Clear();
            Input(text);
        }

        public void Clear()
        {
            DoVIAction("Clear text field", () => GetWebElement().Clear());
        }

        public void SetValue<T>(T value)
        {
            if (value == null) return;
            NewInput(value.ToString());
        }
    }
}