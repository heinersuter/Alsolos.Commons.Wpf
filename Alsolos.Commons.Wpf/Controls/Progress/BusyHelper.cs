﻿namespace Alsolos.Commons.Wpf.Controls.Progress
{
    using System.Collections.Generic;
    using Alsolos.Commons.Wpf.Mvvm;
    using Alsolos.Commons.Wpf.Utils;

    public class BusyHelper : BackingFieldsHolder
    {
        private readonly Stack<string> _stack = new Stack<string>();

        public event ValueEventHandler<bool> IsBusyChanged;

        public bool IsBusy
        {
            get { return BackingFields.GetValue<bool>(); }
            set { BackingFields.SetValue(value, OnIsBusyChanged); }
        }

        public string Message
        {
            get { return BackingFields.GetValue<string>(); }
            set { BackingFields.SetValue(value); }
        }

        public BusyState Enter(string message)
        {
            _stack.Push(message);
            Message = message;
            IsBusy = true;
            return new BusyState(Leave);
        }

        protected virtual void OnIsBusyChanged(bool value)
        {
            var handler = IsBusyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new ValueEventArgs<bool>(value));
            }
        }

        private void Leave()
        {
            _stack.Pop();
            Message = _stack.Count > 0 ? _stack.Peek() : null;
            IsBusy = _stack.Count > 0;
        }
    }
}
