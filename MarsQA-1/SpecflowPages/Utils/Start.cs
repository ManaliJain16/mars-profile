using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using RelevantCodes.ExtentReports;
using TechTalk.SpecFlow;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.Utils
{
    public class Start : Driver
    {

        [BeforeScenario(Order = 0)]
        public void Setup()
        {
            //launch the browser
            Initialize();
            // TODO: fix to use relative path
            ExcelLibHelper.PopulateInCollection(@"C:\Users\manal\OneDrive\Documents\Mars - Profile\mars-profile\MarsQA-1\SpecflowTests\Data\Mars.xlsx", "Credentials");

            //call the SignIn class
            SignIn.SigninStep();
        }

        [AfterScenario]
        public void TearDown()
        {
            //TODO: uncomment 
            // Screenshot
            string img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");
            // test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));

            //Close the browser
            Close();

            // end test. (Reports)
            //CommonMethods.Extent.EndTest(test);

            // calling Flush writes everything to the log file (Reports)
            //CommonMethods.Extent.Flush();
        }
    }
}
