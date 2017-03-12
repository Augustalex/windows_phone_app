using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Laboration_3.Router
{
    public interface IRouter
    {
        void AddGlobalDependencies(params Dependency[] dependencies);
        void CheckpointRoute(string viewName, object contextDependencies = null);
        void RevertToCheckpoint();
        void Route(string viewName, object contextDependencies = null);
        void SetContainer(Window newContainer);
        void SetupRoutes(List<RouterPage> routerPages);
    }
}