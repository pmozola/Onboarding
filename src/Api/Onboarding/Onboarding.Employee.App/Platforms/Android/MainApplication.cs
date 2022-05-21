using Android.App;
using Android.Runtime;

namespace Onboarding.Employee.App
{
    [Application(UsesCleartextTraffic = true)]  // connect to local service   #else 
                                // access via http://10.0.2.2
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}