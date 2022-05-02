using System;

namespace Wifi.ToolsLibrary.ConsoleCore
{
    public abstract class Tools
    {
        public static T GetInputValue<T>(string inputPrompt)
        {
            T inputValue = default(T);
            bool inputIsValid = false;
            Type type = typeof(T);  

            do
            {
                try
                {
                    Console.Write(inputPrompt);
                    //inputValue = int.Parse....
                    var myMethod = type.GetMethod("Parse", new Type[] { typeof(string) });                                                            
                    inputValue = (T)myMethod.Invoke(null, new object[] { Console.ReadLine() });

                    inputIsValid = true;                    
                }
                catch(NullReferenceException)
                {
                    Console.WriteLine("ERROR: Incompatible implementation of 'Parse' detected.");
                    break;
                }
                catch(Exception ex)
                {
                    var message = ex.Message;
                    if(ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                    }

                    Console.WriteLine("ERROR: " + message);
                    inputIsValid = false;
                }
            }
            while (!inputIsValid);

            return inputValue;
        }
    }
}
