﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Laboration_3.Router
{
    public class RouterPage
    {
        private readonly Type _xamlFile;
        private readonly Dictionary<string, object> _dependencies = new Dictionary<string, object>();
        private readonly string _pageName;
        private Frame _frame;

        public RouterPage(string pageName, Type xamlFile)
        {
            _pageName = pageName;
            _xamlFile = xamlFile;
        }

        public RouterPage(Type xamlFile)
        {
            _pageName = xamlFile.Name;
            _xamlFile = xamlFile;
        }

        public Type GetXamlFileType()
        {
            return this._xamlFile;
        }

        public string GetName()
        {
            return this._pageName;
        }

        public Dictionary<string, object> GetDependencies()
        {
            return this._dependencies;
        }

        public Frame Load(object contextDependencies = null)
        {
            if (_frame == null)
            {
                _frame = new Frame();
                _frame.Navigate(this._xamlFile, this._dependencies);
            }

            if (contextDependencies != null)
            {
                this._dependencies["context"] = contextDependencies;
            }

            return _frame;
        }
    }
}
