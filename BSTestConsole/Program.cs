using System;

namespace BSTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
			const string token = "NOTREAL";

			var client = new BaseSpaceDataProvider(token);
			var r = client.GetProjects();
			System.Diagnostics.Debug.WriteLine("Done");
			foreach (var item in r)
				Console.WriteLine(item.Name);

			Console.ReadLine();
		}
    }
}

