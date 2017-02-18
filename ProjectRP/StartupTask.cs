using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace ProjectRP
{
    public sealed class StartupTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            HttpClient client = new HttpClient();
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();

            //
            // Call asynchronous method(s) using the await keyword.
            //
            var result = await client.GetAsync("http://192.168.1.8/RPIoT/api/BG");
            IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();

            using (
                StreamWriter writeFile =
                    new StreamWriter(new IsolatedStorageFileStream("logfile.txt", FileMode.OpenOrCreate, FileAccess.Write,
                        isolatedStorage)))
            {
                string someTextData = "Called at:" + DateTime.Now + ", Result:" + await result.Content.ReadAsStringAsync();
                writeFile.WriteLine(someTextData);
                // writeFile.Close();
            }

            int x = 0;
            while (x < 5)
            {
                x++;
            }
            //
            // Once the asynchronous method(s) are done, close the deferral.
            //
            deferral.Complete();

            // 
            // TODO: Insert code to perform background work
            //
            // If you start any asynchronous methods here, prevent the task
            // from closing prematurely by using BackgroundTaskDeferral as
            // described in http://aka.ms/backgroundtaskdeferral
            //
        }
    }
}
