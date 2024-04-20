namespace Input;

public class Ask 
{
    public static string Options(string question, List<string> options) 
    {
        var processedOptions = new List<string>();
        var optionString = "";

        foreach(var option in options) 
        {
            processedOptions.Add(option.Trim().ToLower().Replace(" ", ""));
            optionString = optionString + " (" + processedOptions.Count + ") " + option + "\n";
        }


        while (true) 
        {
            string response = Prompt("[" + question + "]\n" + optionString).Trim().ToLower().Replace(" ", "");

            int responseInt;

            if (int.TryParse(response, out responseInt))
            {
                responseInt -= 1;
                if (responseInt >= 0 && responseInt < options.Count)
                {
                    return options[responseInt];
                }
            }

            if (processedOptions.Contains(response)) 
            {
                return options[
                    processedOptions.IndexOf(response)
                ];
            }
        }
    }

    
    // TODO add function to ask for int then add one for specified range.
    public static int Int(string message)
    {
        while (true) {
            string response = Prompt(message);
            int responseInt;

            if (int.TryParse(response, out responseInt))
            {
                return responseInt;
            }
        }
    }


    public static string Prompt(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        
        string? response = null;

        while(response == null) 
        {
            response = Console.ReadLine();
        }

        return response;
    }
}

