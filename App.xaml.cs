namespace PM2E15026
{
    public partial class App : Application
    {
        static Controles.UbicacionesControl database;

        public static Controles.UbicacionesControl Database
        {
            get
            {
                if (database == null)
                {
                    database = new Controles.UbicacionesControl();
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
