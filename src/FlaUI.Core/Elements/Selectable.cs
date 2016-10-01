﻿using System;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.Elements
{
    /// <summary>
    /// An UI-item which supports the <see cref="SelectionItemPattern"/>
    /// </summary>
    public class Selectable : Element
    {
        public Selectable(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        public ISelectionItemPattern SelectionItemPattern => PatternFactory.GetSelectionItemPattern();

        public bool IsSelected
        {
            get { return SelectionItemPattern.Current.IsSelected; }
            set
            {
                if (IsSelected == value) return;
                if (value && !IsSelected)
                {
                    Select();
                }
            }
        }

        public void Select()
        {
            var selectionItemPattern = SelectionItemPattern;
            if (selectionItemPattern == null)
            {
                throw new MethodNotSupportedException(String.Format("Select on '{0}' is not supported", ToString()));
            }
            selectionItemPattern.Select();
        }
    }
}
