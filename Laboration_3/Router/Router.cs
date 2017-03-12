using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Laboration_3.Router
{
    public class Router
    {
        private readonly List<string> _viewHistory = new List<string>();
        private readonly Dictionary<string, Frame> _visited = new Dictionary<string, Frame>();
        private readonly Dictionary<string, RouterPage> _pages = new Dictionary<string, RouterPage>();

        private int _checkpointIndex = 0;

        private Window _container = Window.Current;

        public void SetContainer(Window newContainer)
        {
            this._container = newContainer;
        }

        public void Route(string viewName, object contextDependencies = null)
        {
            this._container.Content = VisitPage(viewName, contextDependencies);
        }

        public void CheckpointRoute(string viewName, object contextDependencies = null)
        {
            Route(viewName, contextDependencies);
            _checkpointIndex = this._viewHistory.Count - 1; //Checkpoint sets to latest entry in view history
        }

        public void RevertToCheckpoint()
        {
            if (_checkpointIndex > this._viewHistory.Count)
            {
                throw new Exception("Checkpoint index exceeds the lenght of the view hitory... Cannot revert!");
            }

            Route(this._viewHistory[_checkpointIndex]);
        }

        private Frame VisitPage(string viewName, object contextDependencies = null)
        {
            _viewHistory.Add(viewName);

            if (_visited.ContainsKey(viewName))
            {
                return _visited[viewName];
            }
            else
            {
                var frame = _pages[viewName].Load(contextDependencies);
                _visited[viewName] = frame;
                return frame;
            }
        }
        public void SetupRoutes(List<RouterPage> routerPages)
        {
            foreach (var page in routerPages)
            {
                this._pages[page.GetName()] = page;
            }
        }

        public void AddGlobalDependencies(params Dependency[] dependencies)
        {
            foreach (var page in this._pages.Values)
            {
                foreach (var dependency in dependencies)
                {
                    page.GetDependencies()[dependency.Name] = dependency;
                }
            }
        }
    }
}
