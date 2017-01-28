#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#addin "Cake.Npm"
#addin "Cake.Git"
#addin "Cake.Compression"
#addin "Cake.Powershell"
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Debug");

//////////////////////////////////////////////////////////////////////
// PREPARATION/////////////////////////////////////////////////////////////////////

// Define directories.
var backendSrc = "./Backend/src/";
var backendBuild = Directory(backendSrc + "bin") + Directory(configuration);
var frontEnd = Directory("./Frontend") ;
var package = "package.zip";
//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Setup(context =>
{
    var bin = backendSrc + "bin";
    if(DirectoryExists(bin))
        DeleteDirectory(bin,true);
    
    var obj = backendSrc + "obj";
    if(DirectoryExists(obj))
        DeleteDirectory(obj,true);
    
    if(FileExists(package))
        DeleteFile(package);
});

Task("Npm-FromPath")
    .Does(() =>
{
    Npm.FromPath(frontEnd+Directory("src")).Install();
});
Task("Restore-NuGet-Packages")
    .IsDependentOn("Npm-FromPath")
    .Does(() =>
{
    DotNetCoreRestore(backendSrc+"project.json");
});


Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{

      // Use DotNetCoreBuild
      DotNetCoreBuild("./Backend/src/project.json");
    
});

Task("Package-Sources")
    .IsDependentOn("Build")
    .Does(() => 
{
    var repositoryDirectoryPath = DirectoryPath.FromString(".");
    var currentBranch = GitBranchCurrent(repositoryDirectoryPath);  

    GitClone(currentBranch.Remotes[0].Url, "./temp/");
    Zip("./temp", "package.zip");
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////
Teardown(ctx => {
      if(DirectoryExists("./temp")) 
       StartPowershellScript("Remove-Item", args =>
        {
            args.Append("-Recurse")
                .Append("-Force")
                .AppendQuoted("./temp");
        });   
});


Task("Default")
    .IsDependentOn("Package-Sources");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
