// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Nuke.Common.CI.GitHubActions;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.Coverlet;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.EntityFramework;
using Nuke.Common.Tools.Npm;
using Nuke.Common.Tools.ReportGenerator;
using Nuke.Common.Utilities.Collections;
using Nuke.Common;
using System.Linq;

[GitHubActions("ci",
    GitHubActionsImage.UbuntuLatest,
    AutoGenerate = false,
    OnPushBranches = ["main"], 
    OnPullRequestBranches = ["main"],
    InvokedTargets = [nameof(Init), nameof(Lint), nameof(TestWithCoverage)])]
class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Compile);

    [Solution]
    readonly Solution _solution = default!;

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration _configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    const string ProjectName = "RentCar.*";
    string ProjectPrefix => $"{ProjectName}*";
    const string TestProjectPostfix = "*.Tests";
    const string TestWithCoverageSupportProjectPostfix = "*.UseCase.Tests";
    const string CoverageFolderName = "coverage";
    string CoveragePrefix => $"{CoverageFolderName}.*";
    string CoverageReportFile => "coverage.xml";

    Target Init => d => d
        .Executes(() => NpmTasks.NpmCi());

    Target Clean => d => d
        .Before(Restore)
        .Executes(() => _solution.GetAllProjects(ProjectPrefix)
            .ForEach(project => DotNetTasks.DotNetClean(s => s
                .SetProject(project)
            )));

    Target Reset => d => d
        .Before(Clean)
        .Executes(() => RootDirectory.GlobDirectories(CoverageFolderName).DeleteDirectories())
        .Executes(() => RootDirectory.GlobFiles(CoveragePrefix).DeleteFiles());

    Target Restore => d => d
        .Executes(() => _solution.GetAllProjects(ProjectPrefix)
            .ForEach(project => DotNetTasks.DotNetRestore(s => s
                .SetProjectFile(project)
            )));

    Target Lint => d => d
        .After(Init)
        .Executes(() =>
        {
            NpmTasks.NpmRun(s => s
                .SetCommand("lint"));
            _solution.GetAllProjects(ProjectPrefix)
                .ForEach(project => DotNetTasks.DotNetBuild(s => s
                        .SetProjectFile(project)
                        .AddWarningsAsErrors()));
        });

    Target Format => d => d
        .DependsOn(Restore)
        .After(Lint)
        .Executes(() => _solution.GetAllProjects(ProjectPrefix)
            .ForEach(project => DotNetTasks.DotNetFormat(s => s
                .SetProject(project)
            )));

    Target Compile => d => d
        .DependsOn(Restore)
        .Executes(() => _solution.GetAllProjects(ProjectName)
            .ForEach(project => DotNetTasks.DotNetBuild(s => s
                .SetProjectFile(project)
                .SetNoRestore(true)
            )));

    Target Recompile => d => d
        .DependsOn(Clean, Compile);

    Target Test => d => d
        .DependsOn(Compile)
        .Executes(() => _solution.GetAllProjects(TestProjectPostfix)
            .ForEach(project => DotNetTasks.DotNetTest(s => s
                .SetProjectFile(project)
                .SetConfiguration(_configuration)
                .SetNoRestore(true)
            )));

    Target TestWithCoverage => d => d
        .DependsOn(Compile)
        .After(Lint)
        .Executes(() => _solution.GetAllProjects(TestWithCoverageSupportProjectPostfix)
                .ForEach(project => DotNetTasks.DotNetTest(s => s
                    .SetProjectFile(project)
                    .SetConfiguration(_configuration)
                    .SetCollectCoverage(true)
                    .SetCoverletOutputFormat(CoverletOutputFormat.opencover)
                    .SetCoverletOutput(RootDirectory / CoverageFolderName / CoverageReportFile)
                    .SetExcludeByFile("**/Migrations/*.cs%2C**/Function/*.cs")
                    .SetNoRestore(true)
                )));

    Target Ci => d => d
        .DependsOn(Init, Lint, TestWithCoverage);

    Target GenerateHtmlTestReport => d => d
        .DependsOn(TestWithCoverage)
        .Executes(() => ReportGeneratorTasks.ReportGenerator(s => s
            .SetReports(RootDirectory / CoverageFolderName / CoverageReportFile)
            .SetTargetDirectory(RootDirectory / CoverageFolderName)
            .SetReportTypes(ReportTypes.HtmlInline)
        ));

    Target DbUpdate => d => d
        .DependsOn(Compile)
        .Executes(()
            => EntityFrameworkTasks.EntityFrameworkDatabaseUpdate(s => s
                .SetProject(_solution.GetAllProjects(ProjectName).First())
                .SetConfiguration(_configuration)
                .SetNoBuild(true)
            ));

}
