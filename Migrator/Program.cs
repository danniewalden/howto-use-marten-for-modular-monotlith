using System.Diagnostics;

Console.WriteLine("Creating migrations for modules..");

await CreateMigrationAsync("module1");
await CreateMigrationAsync("module2");

return;

async Task CreateMigrationAsync(string module)
{
	var startInfo = CreateStartInfo(module);
	var proc = Process.Start(startInfo);
	ArgumentNullException.ThrowIfNull(proc);
	var output = proc.StandardOutput.ReadToEnd();
	await proc.WaitForExitAsync();
	Console.WriteLine(output);
}

ProcessStartInfo CreateStartInfo(string module)
{
	var processStartInfo = new ProcessStartInfo
	{
		FileName = "dotnet",
		RedirectStandardInput = true,
		RedirectStandardOutput = true,
		RedirectStandardError = true,
		CreateNoWindow = true,
		UseShellExecute = false,
		Arguments = $"run --project ../../../../Host/Host.csproj -- marten-dump ../../../../{module}.sql -d {module}",
	};
	return processStartInfo;
}
