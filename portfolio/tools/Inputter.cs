namespace Inputter;


public class Ask() {
    static public string Choice(string question, List<string> options) {
        string compiled_options = "";

        var fixed_options = new List<string>();

        foreach (string option in options) {
            compiled_options = compiled_options + option + ", ";
            fixed_options.Add(option.Trim().Replace(" ", "").ToLower());
        }

        compiled_options = compiled_options.Substring(0, compiled_options.Length - 1);

        while (true) {
            Console.Clear();
            Console.WriteLine(question + "\n" + compiled_options);

            var response = Console.ReadLine();

            if (response != null) {
                response = response.Trim().Replace(" ", "").ToLower();
                
                foreach (var option in fixed_options) {
                    if (option == response) {
                        return response;
                    }
                }
            }
        }
    }
}