using Masterdom.Host;

var bootstrapper = new Bootstrapper();

bootstrapper.Start();

Console.WriteLine();
Console.WriteLine("Masterdom Platform is running.");
Console.WriteLine("Press ENTER to stop.");

Console.ReadLine();

bootstrapper.Stop();

Console.WriteLine("Platform stopped.");