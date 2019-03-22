namespace Csh_Kutsenko_01.Tools.Managers
{
    class NavigateManager
    {
        private static NavigateManager instance;

        private static object locker = new object();

        private INavigationModel _navigationModel;

        internal void Innitialize(INavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }
        internal void Navigate(ViewType viewType)
        {
            _navigationModel.Navigate(viewType);
        }
        private NavigateManager()
        {

        }

        internal static NavigateManager Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new NavigateManager();
                    }
                }

                return instance;
            }
        }
    }
}

