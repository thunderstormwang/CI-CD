#addin "nuget:?package=Cake.Docker"

var target = Argument("target", "Default");
var root = Directory(".");
var artifactServer = "nexus.local:8082";

Task("Build")
    .Does(() => {
        var setting = new DockerImageBuildSettings{
            Tag = new string[]{ $"{artifactServer}/health:1" },
            File = $"./scripts/Health/Dockerfile"
        };
        DockerBuild(setting, root);
    });

Task("Default")
    .IsDependentOn("Build");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);