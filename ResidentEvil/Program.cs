using ResidentEvil.BusinessLogic.Console;
using ResidentEvil.Entities;
using ResidentEvil.Interfaces;

namespace ResidentEvil
{
    class Program
    {
        //todo: swap file names
        //Change the json file here by changing the FileName.
        //Note: If you want to create your own stage json. (format must be the same as the given ones)
        //		The file must be in the same folder as the project file
        //		and in the Properties tab "Copy to Ouput Directory" must be set to "Copy if newer".
        public static string FileName => "stage1.json";

        static void Main()
        {
            //todo: Create an instance of Factory here.(your model that implements the IFactory interface)
            IFactory factory = new Factory(); //swap null to an instance of your class
            var app = new ConsoleApplication(FileName, factory);

            app.Run();
        }
    }
}
