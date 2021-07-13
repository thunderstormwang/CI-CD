#addin "nuget:?package=Cake.Docker"

var target = Argument("target", "Default");
var root = Directory(".");
var artifactServer = "nexus.local:8082";

Task("Build")
    .Does(() => {
        var setting = new DockerImageBuildSettings{
            Tag = new string[]{ $"{artifactServer}/health:2" },
            File = $"./scripts/Health/Dockerfile"
        };
        DockerBuild(setting, root);
    });

Task("Push")
    .Does(() => {
        DockerLogin("jenkins", "97533482", artifactServer);
        DockerPush($"{artifactServer}/health:2");
    });

Task("Default")
    .IsDependentOn("Build")
    .IsDependentOn("Push");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);