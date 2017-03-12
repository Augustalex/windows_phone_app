using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Laboration_3.Router
{
    public abstract class ViewController : Page
    {
        private Dictionary<string, object> dependencies;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.dependencies = e.Parameter as Dictionary<string, object>;
        }

    }


}
